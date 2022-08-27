using eCarService.DesktopApp;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCarService.WinUI.Reports
{
    public partial class frmYearlyQuantityReport : Form
    {
        private readonly APIService ReservationService = new APIService("Reservation");

        public frmYearlyQuantityReport()
        {
            InitializeComponent();
        }

        private async void loadData(bool reset = false)
        {
            if (reset)
                graphRevenue.Reset();

            var result = await ReservationService.Get<List<eCarService.Model.Reservation>>(new OrderSearchObject() 
            { Include = "Offer", CarServiceId = ServiceCredentials.ServiceId});

            double[] dataX = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            double[] dataY = new double[12];

            for (int i = 0; i < 12; i++)
            {
                dataY[i] = (result.Where(x => x.Date.Month == i + 1 && x.Date.Year == dateTimePicker1.Value.Year)
                    .Count());
            }
            graphRevenue.Refresh();
            graphRevenue.Plot.AddScatter(dataX, dataY);
            graphRevenue.Refresh();


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            loadData(true);
        }

        private void frmYearlyQuantityReport_Load(object sender, EventArgs e)
        {
            loadData();
        }

  
    }
}
