using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
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
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UserUpdateRequest request = new UserUpdateRequest()
                {
                    Email = _user.Email,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtConfirmationPassword.Text
                };

                await UsersService.Put<User>(_user.UserId, request);

                Application.Restart();
            }
        }

        private bool ValidateInput()
        {
            return 
            Validator.ValidateControl(txtPassword, errorProfileProvider, "Please insert the new password!") &&
            Validator.ValidateControl(txtPassword, errorProfileProvider, "Please confirm the new password!");
        }
    }
}
