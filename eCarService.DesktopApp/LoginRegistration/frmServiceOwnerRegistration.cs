using eCarService.Model;
using eCarService.Model.Helpers;
using eCarService.Model.Requests;
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
            try
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
                        PasswordConfirmation = txtPassConfirmation.Text,
                        Image = ImageHelper.ImageToByteArray(pbImage.Image),
                        RoleId = 3

                    };
                    var user = await UsersService.Post<Model.User>(newUser, true);

                    if (user != null)
                    {
                        MessageBox.Show($"User {user.UserName} successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = "Image Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";

            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = new Bitmap(ofdImage.FileName);
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

            Validator.ValidateControl(txtPassConfirmation, errRegisterProvider, "Please confirm your password!") &&

            Validator.ValidateControl(pbImage, errRegisterProvider, "Please select a picture!");

        }
    }
}
