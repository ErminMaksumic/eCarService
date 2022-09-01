using eCarService.DesktopApp;
using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using eCarService.WinUI.Helpers;
using eCarService.WinUI.LoginRegistration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaService.WinUI.MyProfile
{

    public partial class myProfile : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");
        public APIService UsersPasswordService { get; set; } = new APIService("User/changePassword");
        User _user = null;
        public myProfile()
        {
            InitializeComponent();
        }

        private void myProfile_Load(object sender, EventArgs e)
        {
            loadData();

        }
        private async void loadData()
        {
            _user = await UsersService.GetById<eCarService.Model.User>(ServiceCredentials.UserId);

            txtUsername.Text = _user.UserName;

            pbProfileImage.Image = ImageHelper.ByteArrayToImage(_user.Image);

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                    ValidateInput();
                    MyProfileUpdateRequest req = new MyProfileUpdateRequest()
                    {
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmationPassword.Text,
                        Image = ImageHelper.ImageToByteArray(pbProfileImage.Image)
                    };

                    var result = await UsersPasswordService.Put<User>(_user.UserId, req);

                    if (result != null)
                    {
                        MessageBox.Show($"User successfully edited", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        Application.Restart();
                        this.Close();

                    }

                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ValidateInput()
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
                errorProfileProvider.SetError(txtConfirmationPassword, "This field is required!");
            else
                errorProfileProvider.Clear();
        }

        private void pbProfileImage_Click(object sender, EventArgs e)
        {
            try
            {
                ofdChangeImage.Filter = "Image Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";

                if (ofdChangeImage.ShowDialog() == DialogResult.OK)
                {
                    pbProfileImage.Image = new Bitmap(ofdChangeImage.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
