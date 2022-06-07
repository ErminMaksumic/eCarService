using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using eCarService.WinUI.Helpers;
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
            if (_offerId.HasValue)
            {
                editData();
            }
            else
            {
                loadData();
            }
        }

        private async void editData()
        {
            var offer = await OfferService.GetById<Offer>(_offerId);
            fillInputs(offer);
            loadClbItems(offer);
           
        }

        private async void loadClbItems(Offer offer)
        {
            var parts = await PartService.Get<List<Part>>
               (new PartSearchObject() { CarServiceId = ServiceCredentials.ServiceId });

            clbParts.DataSource = parts;
            clbParts.DisplayMember = "Name";

            for (int i = 0; i < parts.Count; i++)
            {
                if (offer.OfferParts.Where(x => x.PartId == parts[i].PartId).Count() > 0)
                    clbParts.SetItemChecked(i, true);
            }

            var brands = await BrandService.Get<List<CarBrand>>(new CarBrandSearchObject()
            { CarServiceId = ServiceCredentials.ServiceId });

            clbBrands.DataSource = brands;
            clbBrands.DisplayMember = "Name";

            for (int i = 0; i < brands.Count; i++)
            {
                if (offer.CarBrandOffers.Where(x => x.CarBrandId == brands[i].CarBrandId).Count() > 0)
                    clbBrands.SetItemChecked(i, true);
            }
        }

        private void fillInputs(Offer offer)
        {
            txtOfferName.Text = offer.Name;
            numPrice.Value = (decimal)offer.Price;
            pbImage.Image = ImageHelper.ByteArrayToImage(offer.Image);
        }

        private async void loadData()
        {
            CarBrandSearchObject searchBrand = new CarBrandSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId
            };

            var brands = await BrandService.Get<List<CarBrand>>(searchBrand);

            clbBrands.DataSource = brands;
            clbBrands.DisplayMember = "Name";


            PartSearchObject searchPart = new PartSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId
            };

            var parts = await PartService.Get<List<Part>>(searchPart);

            clbParts.DataSource = parts;
            clbParts.DisplayMember = "Name";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {

                var brandList = clbBrands.CheckedItems.Cast<CarBrand>();
                var brandIdList = brandList.Select(x => x.CarBrandId).ToList();

                var partList = clbParts.CheckedItems.Cast<Part>();
                var partIdList = partList.Select(x => x.PartId).ToList();


                OfferUpsertRequest insertRequest = new OfferUpsertRequest()
                {
                    Name = txtOfferName.Text,
                    Brands = brandIdList,
                    Parts = partIdList,
                    CarServiceId = ServiceCredentials.ServiceId,
                    Price = numPrice.Value,
                    Status = "Active",
                    Image  = ImageHelper.ImageToByteArray(pbImage.Image)
                };

                Offer result;

                if (_offerId.HasValue)
                {
                    result = await OfferService.Put<Offer>(_offerId, insertRequest);
                    if (result != null)
                    {
                        MessageBox.Show($"Offer {insertRequest.Name} was successfuly edited!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    result = await OfferService.Post<Offer>(insertRequest);
                    if (result != null)
                    {
                        MessageBox.Show($"Offer {insertRequest.Name} was successfuly created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
        }

        private bool ValidateInputs()
        {
            return
            Validator.ValidateControl(txtOfferName, errorOfferProvider, "Name is required field!") &&
            Validator.ValidateControl(pbImage, errorOfferProvider, "You must upload an image!");
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            ofdPicture.Filter = "Image Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";

            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = new Bitmap(ofdPicture.FileName);
            }
        }
    }
}