using eCarService.Model;
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

namespace eProdajaService.WinUI.Offers
{
    public partial class frmAddNewOffer : Form
    {
        private readonly APIService PartService = new APIService("Part");
        private readonly APIService BrandService = new APIService("CarBrand");
        private readonly APIService OfferService = new APIService("Offer");
        int? _offerId = null;

        public frmAddNewOffer(int? id = null)
        {
            InitializeComponent();
            _offerId = id;
        }

        private void frmAddNewOffer_Load(object sender, EventArgs e)
        {
            if (!_offerId.HasValue)
            {
                loadParts();
                loadBrands();
            }
            else
            {
                loadEditBrands();
            }
        }

        private async void loadBrands()
        {
            CarBrandSearchObject search = new CarBrandSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId
            };

            var brands = await BrandService.Get<List<CarBrand>>(search);

            clbBrands.DataSource = brands;
            clbBrands.DisplayMember = "Name";
        }

        private async void loadEditBrands()
        {
            var offer = await OfferService.GetById<Offer>(_offerId);


            List<CarBrand> list = new List<CarBrand>();

            foreach (var item in offer?.CarBrandOffers)
            {
                list.Add(item.CarBrand);
            }

            clbBrands.DataSource = list;
            clbBrands.DisplayMember = "Name";
        }

        private async void loadParts()
        {
            PartSearchObject search = new PartSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId
            };

            var parts = await PartService.Get<List<Part>>(search);

            clbParts.DataSource = parts;
            clbParts.DisplayMember = "Name";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var ulogeList = clbBrands.CheckedItems.Cast<CarBrand>();
            var ulogeIdList = ulogeList.Select(x => x.CarBrandId).ToList();

            OfferInsertRequest insertRequest = new OfferInsertRequest()
            {
                Name = txtOfferName.Text,
                Brands = ulogeIdList,
                CarServiceId = ServiceCredentials.ServiceId,
                Price = numPrice.Value,
                Status = "Active"
            };

            await OfferService.Post<Offer>(insertRequest);

            MessageBox.Show($"Offer {insertRequest.Name} was successfuly created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
