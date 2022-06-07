using eCarService.Model;
using eCarService.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCarService.WinUI.LoginRegistration
{

    public partial class frmServiceOwnerRegistration : Form
    {
        public APIService UsersService { get; set; } = new APIService("User");
        public APIService CarService { get; set; } = new APIService("CarService");
        public frmServiceOwnerRegistration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            addNewUser();
        }

        private async void addNewUser()
        {
            if (ValidateInputs())
            {
                UserInsertRequest newUser = new UserInsertRequest()
                {
                    UserName = txtUsername.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConfirmation.Text
                };
                var user = await UsersService.Post<User>(newUser);

                if (user != null)
                {
                    CarServiceInsertRequest newService = new CarServiceInsertRequest()
                    {
                        Name = txtServiceName.Text,
                        Address = txtServiceAddress.Text,
                        PhoneNumber = txtServicePhoneNumber.Text,
                        DateCreated = DateTime.Now,
                        UserId = user.UserId
                    };

                    await CarService.Post<CarService>(newService);


                    MessageBox.Show($"User {user.UserName} succesfully registered!");
                }
            }

        }

        private bool ValidateInputs()
        {
            return
            Validator.ValidateControl(txtUsername, errRegisterProvider, "Username is required!") &&

            Validator.ValidateControl(txtEmail, errRegisterProvider, "Email is required field!") &&

            Validator.ValidateControl(txtFirstName, errRegisterProvider, "First name is required field!") &&

            Validator.ValidateControl(txtLastName, errRegisterProvider, "Last name is required field!") &&

            Validator.ValidateControl(txtPassword, errRegisterProvider, "Password is required field!") &&

            Validator.ValidateControl(txtPasswordConfirmation, errRegisterProvider, "Please confirm your password!") &&

            Validator.ValidateControl(txtServiceAddress, errRegisterProvider, "Address is required field!") &&

            Validator.ValidateControl(txtServicePhoneNumber, errRegisterProvider, "Phone number is required field!"); 
        }
    }
}
