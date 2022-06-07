using eCarService.Model.Requests;
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

namespace eCarService.WinUI.Administration
{
    public partial class frmUserDetails : Form
    {
        private readonly APIService UserService = new APIService("User");
        private Model.User User;

        private int userId = -1;
        public frmUserDetails(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            User = await UserService.GetById<Model.User>(userId);

            inputData();
        }

        private void inputData()
        {
            txtUsername.Text = User.UserName;
            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            txtEmail.Text = User.Email;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteUser(User.UserId);
        }

        private async void deleteUser(int userId)
        {
            await UserService.Delete<Model.User>(userId);

            MessageBox.Show($"User with id: {userId} is deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            editUser(User.UserId);
        }

        private async void editUser(int userId)
        {
            if (ValidateInputs())
            {
                UserUpdateRequest userUpdateRequest = new UserUpdateRequest()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPassword.Text
                };

                var result = await UserService.Put<Model.User>(userId, userUpdateRequest);

                if (result != null)
                {
                    MessageBox.Show($"User {userUpdateRequest.FirstName} was successfuly updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private bool ValidateInputs()
        {
            return

            Validator.ValidateControl(txtEmail, errUserDetailsProvider, "Email is required field!") &&

            Validator.ValidateControl(txtFirstName, errUserDetailsProvider, "First name is required field!") &&

            Validator.ValidateControl(txtLastName, errUserDetailsProvider, "Last name is required field!");
        }
    }
}