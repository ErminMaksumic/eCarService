﻿using eCarService.DesktopApp;
using eCarService.Model;
using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdajaService.WinUI.Parts
{
    public partial class frmParts : Form
    {
        private readonly APIService PartService = new APIService("Part");
        public frmParts()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchParts();
        }

        private void searchParts()
        {
            loadData();
        }

        private void frmParts_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            PartSearchObject search = new PartSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                Name = txtSearch.Text
            };
            
            var result = await PartService.Get<List<eCarService.Model.Part>>(search);
            dgvParts.AutoGenerateColumns = false;
            dgvParts.DataSource = result;
        }

        private void dgvParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editPart();
            }
        }

        private void editPart()
        {

            var data = dgvParts.SelectedRows[0].DataBoundItem as Part;

            Form form = new frmCreationParts(data.PartId);
            form.ShowDialog();

            loadData();
        }
    }
}
