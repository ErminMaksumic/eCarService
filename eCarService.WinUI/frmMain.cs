using eCarService.WinUI;
using eCarService.WinUI.Brands;
using eProdajaService.WinUI.Administration;
using eProdajaService.WinUI.MyProfile;
using eProdajaService.WinUI.Offers;
using eProdajaService.WinUI.Orders;
using eProdajaService.WinUI.Parts;
using eProdajaService.WinUI.Ratings;

namespace eProdajaService.WinUI
{
    public partial class frmMain : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");
        public frmMain()
        {
            InitializeComponent();
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

        private void ordersItem_Click(object sender, EventArgs e)
        {
            Form form = new frmOrderList();

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

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadWlcmMessage();
        }

        private async void loadWlcmMessage()
        {
            var result = await UsersService.GetById<eCarService.Model.User>(ServiceCredentials.UserId);
            lblUserName.Text = result.UserName;
        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmUserList();

            form.ShowDialog();
        }
    }
}