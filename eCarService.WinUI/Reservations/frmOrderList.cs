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
        public frmOrderList()
        {
            InitializeComponent();
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            loadOrders();
            setDefaultValues();
        }

        private void setDefaultValues()
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddYears(1);
        }

        private async void loadOrders()
        {
            OrderSearchObject search = new OrderSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                From = dtpFrom.Value,
                To = dtpTo.Value
            };

            var result = await ReservationService.Get<List<eCarService.Model.Reservation>>(search);
            dgvOrderList.AutoGenerateColumns = false;
            dgvOrderList.DataSource = result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
        }

        private async void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                var item = dgvOrderList.Rows[e.RowIndex].DataBoundItem as eCarService.Model.Reservation;

                if (e.ColumnIndex == dgvOrderList.Columns["CompleteServ"].Index && e.RowIndex >= 0 &&
                item.Status!="Done")
                {
                var updateRequest = new ReservationInsertRequest()
                {
                    Date = item.Date,
                    OfferId = item.OfferId,
                    UserId = item.UserId,
                    Status = "Done"
                };

                await ReservationService.Put<eCarService.Model.Reservation>(item.ReservationId, updateRequest);
                loadOrders();
                MessageBox.Show("Service is now done!");
            }
                else
            {
                MessageBox.Show("Service is already done!");
            }    
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            loadOrders();
        }
    }
}
