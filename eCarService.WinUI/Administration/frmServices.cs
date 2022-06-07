using eCarService.Model;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using eCarService.WinUI.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaService.WinUI.Administration
{
    public partial class frmServices : Form
    {
        public APIService CarService { get; set; } = new APIService("CarService");

        public frmServices()
        {
            InitializeComponent();
        }

        private void frmServices_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData(CarServiceSearchObject search = null)
        {
            var result = await CarService.Get<List<eCarService.Model.CarService>>(search);
            dgvServices.AutoGenerateColumns = false;
            dgvServices.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchDataObject = new CarServiceSearchObject();
            searchDataObject.Address = txtSearch.Text;

            loadData(searchDataObject);
        }

        private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetailsForm();
        }

        private void showDetailsForm()
        {
            var data = dgvServices.SelectedRows[0].DataBoundItem as CarService;
            Form form = new frmServiceDetails(data.CarServiceId);
            form.ShowDialog();

            loadData();
        }
    }
}
