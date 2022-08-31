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
    public partial class frmUsers : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");


        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            UserSearchObject searchObject = new UserSearchObject()
            {
                FullName = txtSearch.Text
            };
            var result = await UsersService.Get<List<eCarService.Model.User>>(searchObject);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchUsers();
        }

        private void searchUsers()
        {
            loadData();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                showDetailsForm();
                loadData();
            }
        }

        private void showDetailsForm()
        {
            var data = dgvUsers.SelectedRows[0].DataBoundItem as User;
            frmUserDetails form = new frmUserDetails(data.UserId);
            form.ShowDialog();
        }

    }
}
