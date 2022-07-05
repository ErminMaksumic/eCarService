using eCarService.DesktopApp;
using eCarService.Model;
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

namespace eProdajaService.WinUI.Offers
{
    public partial class frmMyOfferList : Form
    {
        private readonly APIService OfferService = new APIService("Offer");
        public frmMyOfferList()
        {
            InitializeComponent();
        }

        private void frmMyOfferList_Load(object sender, EventArgs e)
        {
            loadOffers();
        }

        private async void loadOffers()
        {
            OfferSearchObject search = new OfferSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                Name = txtSearch.Text
            };

            var result = await OfferService.Get<List<eCarService.Model.Offer>>(search);
            dgvOffers.AutoGenerateColumns = false;
            dgvOffers.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadOffers();
        }

        private void dgvOffers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dgvOffers.SelectedRows[0].DataBoundItem as Offer;

            Form editForm = new frmAddNewOffer(data.OfferId);

            editForm.ShowDialog();
            loadOffers();
        }

        private async void dgvOffers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvOffers.Rows[e.RowIndex].DataBoundItem as eCarService.Model.Offer;

            if (e.ColumnIndex == dgvOffers.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Do you want to delete this offer?", "Delete offer", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    await OfferService.Delete<eCarService.Model.Offer>(item.OfferId);

                    loadOffers();

                    MessageBox.Show($"Offer successfuly deleted!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
        }
    }
}
