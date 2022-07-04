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

namespace eCarService.WinUI.Administration
{
    public partial class frmServiceDetails : Form
    {
        public APIService CarService { get; set; } = new APIService("CarService");
        private readonly APIService UserChangeRole = new APIService("User/changeRole");

        private Model.CarService Service;

        private int carServiceId = -1;
        public frmServiceDetails(int carServiceId)
        {
            InitializeComponent();
            this.carServiceId = carServiceId;
        }

        private void frmServiceDetails_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private async void loadData()
        {
            Service = await CarService.GetById<Model.CarService>(carServiceId);

            inputData();
        }

        private void inputData()
        {
            txtAddress.Text = Service.Address;
            txtDateCreated.Text = Service.DateCreated.ToString();
            txtPhoneNumber.Text = Service.PhoneNumber;
            txtName.Text = Service.Name;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                CarServiceUpdateRequest carServiceUpdateRequest = new CarServiceUpdateRequest()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                };

                var result = await CarService.Put<Model.CarService>(carServiceId, carServiceUpdateRequest);

                if (result != null)
                {
                    MessageBox.Show($"Service {carServiceUpdateRequest.Address} was successfuly updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }


        public bool ValidateInputs()
        {
            return

           Validator.ValidateControl(txtAddress, errCarServDetailsProvider, "Address is required field!") &&

           Validator.ValidateControl(txtPhoneNumber, errCarServDetailsProvider, "Phone number is required field!")

           && Validator.ValidateControl(txtName, errCarServDetailsProvider, "Name is required field!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Do you want to delete this service?", "Delete service", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                deleteService();
            }
        }

        private async void deleteService()
        {
            var result = await CarService.Delete<Model.CarService>(carServiceId);

            if (result != null)
            {
                RoleUpdateRequest request = new RoleUpdateRequest() { RoleId = 3 };
                await UserChangeRole.Put<Model.User>(Service.UserId, request);
                MessageBox.Show($"Service with id: {carServiceId} was deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
