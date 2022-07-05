using eCarService.DesktopApp;
using eCarService.Model;
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
    public partial class frmServiceRegistration : Form
    {
        public APIService CarService { get; set; } = new APIService("CarService");
        public APIService UserService { get; set; } = new APIService("User");
        public APIService UserChangeRoleService { get; set; } = new APIService("User/changeRole");

        public frmServiceRegistration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            saveService();
        }

        private async void saveService()
        {
            if (ValidateInputs())
            {
                CarServiceInsertRequest newService = new CarServiceInsertRequest()
                {
                    Name = txtServiceName.Text,
                    Address = txtServiceAddress.Text,
                    PhoneNumber = txtServicePhoneNumber.Text,
                    DateCreated = DateTime.Now,
                    UserId = ServiceCredentials.UserId
                };

                var service = await CarService.Post<CarService>(newService);

                if (service != null)
                {
                    MessageBox.Show($"Service {service.Name} successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changeUserRoleId();
                    Application.Restart();
                }
            }
        }

        private async void changeUserRoleId()
        {
            RoleUpdateRequest req = new RoleUpdateRequest() { RoleId = 2 };

            await UserChangeRoleService.Put<Model.User>(ServiceCredentials.UserId, req);
        }

        private bool ValidateInputs()
        {
            return
                Validator.ValidateControl(txtServicePhoneNumber, errServiceProvider, "Phone number is required field!") &&
                Validator.ValidateControl(txtServiceName, errServiceProvider, "Name is required field!") &&
                Validator.ValidateControl(txtServiceAddress, errServiceProvider, "Address is required field!");
        }
    }
}
