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

namespace eCarService.WinUI.Administration
{
    public partial class frmAdditionalServices : Form
    {
        public APIService AdditionalService { get; set; } = new APIService("AdditionalService");

        public frmAdditionalServices()
        {
            InitializeComponent();
        }

        private void ManageAdditionalServices_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            AdditionalServiceSearchObject search = new AdditionalServiceSearchObject()
            {
                Name = txtSearch.Text
            };

            var result = await AdditionalService.Get<List<eCarService.Model.AdditionalService>>(search);
            dgvAdditionalServices.AutoGenerateColumns = false;
            dgvAdditionalServices.DataSource = result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submitNewAdditionalService();

        }

        private async void submitNewAdditionalService()
        {
            if (validateInputs())
            {
                AdditionalServiceUpsertRequest insertRequest = new AdditionalServiceUpsertRequest()
                {
                    Description = txtDescription.Text,
                    Price = numPrice.Value,
                    Name = txtName.Text
                };

                var result = await AdditionalService.Post<AdditionalService>(insertRequest);

                if (result != null)
                {
                    MessageBox.Show($"AdditionalService {insertRequest.Name} was successfuly created!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadData();
                    clearInputs();
                }
            }
        }

        private bool validateInputs()
        {
            return
            Validator.ValidateControl(txtName, errAdditionalProvider, "Name is required field!");
        }

        private void clearInputs()
        {
            txtName.Clear();
            txtDescription.Clear();
            numPrice.Value = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private async void dgvAdditionalServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvAdditionalServices.Rows[e.RowIndex].DataBoundItem as eCarService.Model.AdditionalService;

            if (e.ColumnIndex == dgvAdditionalServices.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                await AdditionalService.Delete<eCarService.Model.AdditionalService>(item.AdditionalServiceId);

                loadData();

                MessageBox.Show($"AdditionalService successfuly deleted!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }    
        }
    }
}
