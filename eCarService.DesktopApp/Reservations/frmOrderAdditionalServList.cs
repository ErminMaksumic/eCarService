using eCarService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCarService.DesktopApp.Reservations
{
    public partial class frmOrderAdditionalServList : Form
    {
        Reservation item;
        public frmOrderAdditionalServList(Reservation item)
        {
            this.item = item;
            InitializeComponent();
        }

        private void frmOrderAdditionalServList_Load(object sender, EventArgs e)
        {
            loadAddServices();
        }

        private void loadAddServices()
        {
            dgvAddServices.AutoGenerateColumns = false;
            dgvAddServices.DataSource = item.AdditionalServ;
        }

   
    }
}
