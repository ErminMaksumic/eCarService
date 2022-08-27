using eCarService.DesktopApp;
using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
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

namespace eCarService.WinUI.Brands
{
    public partial class frmBrand : Form
    {
        private readonly APIService BrandService = new APIService("CarBrand");
        CarBrand _carBrand;

        public frmBrand()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadBrands();

        }
        private void frmBrand_Load(object sender, EventArgs e)
        {
            loadBrands();
        }

        private async void loadBrands()
        {
            CarBrandSearchObject search = new CarBrandSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                Name = txtSearch.Text
            };

            var result = await BrandService.Get<List<eCarService.Model.CarBrand>>(search);
            dgvBrands.AutoGenerateColumns = false;
            dgvBrands.DataSource = result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submitNewData();
        }

        private async void submitNewData()
        {
            if (ValidateInsertInput())
            {
                CarBrandUpsertRequest request = new CarBrandUpsertRequest()
                {
                    Name = txtName.Text,
                    CarServiceId = ServiceCredentials.ServiceId
                };

                var result = await BrandService.Post<dynamic>(request);

                if (result != null)
                {
                    MessageBox.Show($"Brand {request.Name} was successfuly added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    loadBrands();
                }
            }
        }

        private void dgvBrands_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _carBrand = dgvBrands.SelectedRows[0].DataBoundItem as CarBrand;
            txtEditName.Text = _carBrand.Name;
        }

        private async void btnEditSubmit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtEditName.Text) && _carBrand != null && ValidateEditInput())
            {
                CarBrandUpsertRequest request = new CarBrandUpsertRequest()
                {
                    Name = txtEditName.Text,
                    CarServiceId = _carBrand.CarServiceId
                };

                
                var update = await BrandService.Put<dynamic>(_carBrand.CarBrandId, request);

                if (update != null)
                {
                    MessageBox.Show($"Brand {request.Name} was successfuly edited!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtEditName.Clear();
                loadBrands();

            }
            else
            {
                MessageBox.Show("You have to double click on cell and type data in edit field", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            txtEditName.Clear();

        }

        private bool ValidateInsertInput()
        {
            return Validator.ValidateControl(txtName, errBrandProvider, "Name is required field!");
        }
        private bool ValidateEditInput()
        {
            return Validator.ValidateControl(txtEditName, errBrandProvider, "Name is required field!");
        }

        private void dgvBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteBrand(sender, e);
        }

        private async void deleteBrand(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBrands.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                    var item = dgvBrands.Rows[e.RowIndex].DataBoundItem as eCarService.Model.CarBrand;
                    var result = await BrandService.Delete<eCarService.Model.CarBrand>(item.CarBrandId);

                    if (result != null)
                    {
                        loadBrands();

                        txtEditName.Clear();

                        MessageBox.Show($"Brand is successfuly deleted!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
           

           
        }
    }
}
