using eCarService.Model.SearchObjects;
using eProdajaService.WinUI;
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
    public partial class frmLogin : Form
    {
        private readonly APIService UserService = new APIService("User");
        private readonly APIService CarService = new APIService("CarService");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Submitlogin();
        }



        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Submitlogin();
        }


        private async Task Submitlogin()
        {
            try
            {
                if (ValidateInputs())
                {
                    APIService.Username = txtUsername.Text;
                    APIService.Password = txtPassword.Text;

                    //var userResult = await UserService.Get<List<Model.User>>();

                    UserSearchObject userSearch = new UserSearchObject() { UserName = txtUsername.Text };

                    var userResult2 = await UserService.Get<List<Model.User>>(userSearch);


                    var carServiceResult = await CarService.Get<List<Model.CarService>>(new CarServiceSearchObject()
                    {
                        UserId = userResult2.First().UserId
                    });

                    ServiceCredentials.ServiceId = carServiceResult.First().CarServiceId;
                    ServiceCredentials.UserId = userResult2.First().UserId;



                    frmMain frm = new frmMain();
                    this.Hide();
                    frm.ShowDialog();
                    errLoginProvider.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid username or/and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openRegisterForm();
        }

        private void openRegisterForm()
        {
            Form form = new frmServiceOwnerRegistration();

            form.ShowDialog();
        }

        private bool ValidateInputs()
        {
            return
            Validator.ValidateControl(txtUsername, errLoginProvider, "Please enter the username!") &&

            Validator.ValidateControl(txtPassword, errLoginProvider, "Please enter the password!");
        }
    }
}
   