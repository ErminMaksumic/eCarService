using eCarService.DesktopApp;
using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.WinUI;
using eCarService.WinUI.Helpers;
using eProdajaService.WinUI.Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaService.WinUI
{
    public partial class frmCreationParts : Form
    {
        private readonly APIService PartService = new APIService("Part");
        int? _partId;

        public frmCreationParts(int? id = null)
        {
            InitializeComponent();
            this._partId = id;

            if (this._partId.HasValue)
                fillInputs();
            else
                btnDelete.Hide();

        }

        private async void fillInputs()
        {
            var data = await PartService.GetById<Part>(_partId);

            txtPartName.Text = data.Name;
            numUpQuantity.Value = (int)data.Quantity;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveNewPart();
        }

        private async void SaveNewPart()
        {
            if (ValidateInput()) {
            PartUpsertRequest request = new PartUpsertRequest()
            {
                Name = txtPartName.Text,
                Quantity = (int)numUpQuantity.Value,
                CarServiceId = ServiceCredentials.ServiceId
            };

            if (!_partId.HasValue)
            {
                await PartService.Post<dynamic>(request);

                MessageBox.Show($"Part {request.Name} was successfuly created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                await PartService.Put<dynamic>(_partId, request);

                MessageBox.Show($"Part {request.Name} was successfuly edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Form form = new frmParts();
            this.Close();
            form.ShowDialog();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deletePart();
        }

        private async void deletePart()
        {
            var confirmResult = MessageBox.Show("Do you want to delete this part?", "Delete part", MessageBoxButtons.YesNo);
            
            if (confirmResult == DialogResult.Yes)
            {
                await PartService.Delete<Part>(_partId);

            }

            this.Close();
        }
        private bool ValidateInput()
        {
            return Validator.ValidateControl(txtPartName, errPartsProvider, "Name is required field!");
        }

       
    }
    
}
