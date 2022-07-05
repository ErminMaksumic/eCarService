using eCarService.DesktopApp;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCarService.WinUI.Reservations
{
    public partial class frmCustomOfferRequest : Form
    {
        private readonly APIService CustomServiceRequest = new APIService("CustomOfferRequest");
        private readonly APIService CustomServiceChangeStatus = new APIService("CustomOfferRequest/changeStatus");

        public frmCustomOfferRequest()
        {
            InitializeComponent();
        }

        private void frmCustomServiceRequest_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            CustomOfferSearchObject search = new CustomOfferSearchObject()
            {
                Name = txtSearch.Text,
                CarServiceId = ServiceCredentials.ServiceId
            };

            var result = await CustomServiceRequest.Get<List<eCarService.Model.CustomOfferRequest>>(search);
            dgvCustomReqLIst.AutoGenerateColumns = false;
            dgvCustomReqLIst.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private async void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvCustomReqLIst.Rows[e.RowIndex].DataBoundItem as eCarService.Model.CustomOfferRequest;

            if (e.ColumnIndex == dgvCustomReqLIst.Columns["CompleteServ"].Index && e.RowIndex >= 0 &&
            item.Status != "Done")
            {
                var updateRequest = new ChangeStatusRequest()
                {
                    Status = "Done"
                };

                await CustomServiceChangeStatus.Put<eCarService.Model.CustomOfferRequest>
                (item.CustomReqId, updateRequest);

                loadData();

                MessageBox.Show("Service is now done!");
            }
            else
            {
                MessageBox.Show("Service is already done!");
            }
        }
    }
}
