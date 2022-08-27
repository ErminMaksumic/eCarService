using eCarService.DesktopApp;
using eCarService.DesktopApp.Reservations;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaService.WinUI.Orders
{
    public partial class frmOrderList : Form
    {
        private readonly APIService ReservationService = new APIService("Reservation");
        private readonly APIService CustomServiceChangeStatus = new APIService("Reservation/changeStatus");

        public frmOrderList()
        {
            InitializeComponent();
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            setDefaultValues();
            loadOrders();
        }

        private void setDefaultValues()
        {
            dtpFrom.Value = DateTime.Now.AddYears(-1);
            dtpTo.Value = DateTime.Now.AddYears(1);
        }

        private async void loadOrders()
        {
            OrderSearchObject search = new OrderSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                From = dtpFrom.Value,
                To = dtpTo.Value,
                Name = txtSearch.Text
            };

            var result = await ReservationService.Get<List<eCarService.Model.Reservation>>(search);
            dgvOrderList.AutoGenerateColumns = false;
            dgvOrderList.DataSource = result;
        }


        private async void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvOrderList.Columns["CompleteServ"].Index && e.RowIndex >= 0)
            {
                var item = dgvOrderList.Rows[e.RowIndex].DataBoundItem as eCarService.Model.Reservation;

                if (item.Status != "Done")
                {
                    var updateRequest = new ChangeStatusRequest()
                    {
                        Status = "Done"
                    };

                    await CustomServiceChangeStatus.Put<eCarService.Model.CustomOfferRequest>
                    (item.ReservationId, updateRequest);

                    loadOrders();

                    MessageBox.Show("Service is now done!");

                }
                else
                {
                    MessageBox.Show("Service is already done!");
                }

            }

            if (e.ColumnIndex == dgvOrderList.Columns["AdditionalServices"].Index && e.RowIndex >= 0)
            {
                var item = dgvOrderList.Rows[e.RowIndex].DataBoundItem as eCarService.Model.Reservation;
                Form form = new frmOrderAdditionalServList(item);
                form.ShowDialog();
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            loadOrders();
        }
    }
}
