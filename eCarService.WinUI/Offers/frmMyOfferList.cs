using eCarService.Model;
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
            var result = await OfferService.Get<List<eCarService.Model.Offer>>();
            dgvOffers.AutoGenerateColumns = false;
            dgvOffers.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvOffers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dgvOffers.SelectedRows[0].DataBoundItem as Offer;

            Form editForm = new frmAddNewOffer(data.OfferId);

            editForm.ShowDialog();
        }
    }
}
