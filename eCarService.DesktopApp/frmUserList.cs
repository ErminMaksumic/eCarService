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

namespace eCarService.WinUI
{
    public partial class frmUserList : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");

        public frmUserList()
        {
            InitializeComponent();
        }

        private void UsersList_Load(object sender, EventArgs e)
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
            loadData();
        }
    }
}
