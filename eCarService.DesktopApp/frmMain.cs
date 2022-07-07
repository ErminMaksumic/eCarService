using eCarService.DesktopApp;
using eCarService.DesktopApp.Reports;
using eCarService.Model;
using eCarService.WinUI;
using eCarService.WinUI.Administration;
using eCarService.WinUI.Brands;
using eCarService.WinUI.LoginRegistration;
using eCarService.WinUI.Reports;
using eCarService.WinUI.Reservations;
using eProdajaService.WinUI.Administration;
using eProdajaService.WinUI.MyProfile;
using eProdajaService.WinUI.Offers;
using eProdajaService.WinUI.Orders;
using eProdajaService.WinUI.Parts;
using eProdajaService.WinUI.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eProdajaService.WinUI
{
    public partial class frmMain : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");
        public APIService CarServiceService { get; set; } = new APIService("CarService");
        User _user = null;
        public frmMain()
        {
            InitializeComponent();
        }
        private async void validateUser()
        {
            _user = await UsersService.GetById<eCarService.Model.User>(ServiceCredentials.UserId);
            lblUserName.Text = _user.UserName;

            var result = await CarServiceService.Get<List<eCarService.Model.CarService>>();

            var service = result.FirstOrDefault(x => x.UserId == _user.UserId);


            if (service != null && _user.Role.Name == "ServiceRegistered")
            {
                btnCreateService.Hide();
                ServiceCredentials.ServiceId = service.CarServiceId;
                showControls(true);
            }
            else if (service != null && _user.Role.Name == "Administrator")
            {
                btnCreateService.Hide();
                ServiceCredentials.ServiceId = service.CarServiceId;
                showControls(true);

                administrationStripMenu.Visible = true;
            }
            else
                showControls(false);
          

        }

        private void myOffersItem_Click(object sender, EventArgs e)
        {
            Form form = new frmMyOfferList();

            form.ShowDialog();
        }

        private void addNewOfferItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewOffer();

            form.ShowDialog();
        }
        private void ratingsItem_Click(object sender, EventArgs e)
        {
            Form form = new frmRatingList();

            form.ShowDialog();
        }

        private void mProfileItem_Click(object sender, EventArgs e)
        {
            Form form = new myProfile();

            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUsers();

            form.ShowDialog();
        }

        private void servicesItem_Click(object sender, EventArgs e)
        {
            Form form = new frmServices();

            form.ShowDialog();
        }

        private void ratingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new frmManageRatings();

            form.ShowDialog();
        }

        private void addNewPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCreationParts();

            form.ShowDialog();
        }

        private void myPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmParts();

            form.ShowDialog();
        }

        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmBrand();

            form.ShowDialog();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            validateUser();
            administrationStripMenu.Visible = false;

        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUserList();

            form.ShowDialog();
        }
        private void additionalServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAdditionalServices();

            form.ShowDialog();
        }

        private void showControls(bool flag)
        {
            offersStripMenu.Visible = flag;
            ordersStripMenu.Visible = flag;
            brandsStripMenu.Visible = flag;
            partsStripMenu.Visible = flag;
            ratingsStripMenu.Visible = flag;
            reportsStripMenu.Visible = flag;
        }

        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmOrderList();

            form.ShowDialog();
        }

        private void customServiceRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCustomOfferRequest();

            form.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to logout from the app ?", "Logout", MessageBoxButtons.YesNo);

            if(confirmResult == DialogResult.Yes)
            {
             Application.Restart();
            }

        }
        private void lastYearRevenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmRevenueReport();
            form.ShowDialog();
        }

        private void bestSellingOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAnnualQuantityReport();
            form.ShowDialog();
        }

        private void btnCreateService_Click_1(object sender, EventArgs e)
        {
            Form form = new frmServiceRegistration();

            form.ShowDialog();
        }
    }
}