using eCarService.Model.SearchObjects;
using eCarService.DesktopApp;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eCarService.WinUI;

namespace eCarService.DesktopApp.Reports
{
    public partial class frmRevenueReport : Form
    {
        private readonly APIService ReservationService = new APIService("Reservation");
        private readonly APIService UserService = new APIService("User");
        public frmRevenueReport()
        {
            InitializeComponent();
        }

        private void frmRevenueReport_Load(object sender, EventArgs e)
        {

            loadReport();
           
        }

        private async void loadReport(bool refresh = false)
        {

            
            ReportParameterCollection parameters = new ReportParameterCollection();


            var tblRevenue = new dsAnnualRevenue.AnnualRevenueDataTable();

            var result = await ReservationService.Get<List<eCarService.Model.Reservation>>(new OrderSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                ExcludeDefaultValues = true
            });

            var user = await UserService.GetById<Model.User>(ServiceCredentials.UserId);

            parameters.Add(new ReportParameter("carServiceName", user.UserName));
            parameters.Add(new ReportParameter("revenueSum", result.Where(x=> x.Date.Year == dtpYear.Value.Year).Sum(x=> x.Offer.Price).ToString()));


            for (int i = 1; i <= 12; i++)
            {
                var row = tblRevenue.NewAnnualRevenueRow();
                row.Month = i;
                row.Revenue = (double)result.Where(x => x.Date.Month == i  && x.Date.Year == dtpYear.Value.Year).Sum(x => x.Offer.Price);
                tblRevenue.AddAnnualRevenueRow(row);

            }

            if (refresh)
            {
                reportViewer1.LocalReport.DataSources.RemoveAt(0);
            }

            ReportDataSource dataSource = new ReportDataSource();
           
            dataSource.Name = "dsAnnualRevenue";
            dataSource.Value = tblRevenue;

            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            loadReport(true);
        }

        private void btnGraphic_Click(object sender, EventArgs e)
        {
            Form form = new frmYearlyRevenueReport();
            form.ShowDialog();
        }
    }
}
