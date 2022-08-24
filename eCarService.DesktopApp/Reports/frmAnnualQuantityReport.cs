using eCarService.Model.SearchObjects;
using eCarService.WinUI;
using eCarService.WinUI.Reports;
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

namespace eCarService.DesktopApp.Reports
{
    public partial class frmAnnualQuantityReport : Form
    {
    
        private readonly APIService ReservationService = new APIService("Reservation");
        private readonly APIService UserService = new APIService("User");
        public frmAnnualQuantityReport()
        {
            InitializeComponent();
        }

        private async void loadReport(bool refresh = false)
        {


            ReportParameterCollection parameters = new ReportParameterCollection();


            var tblQuantity = new dsAnnualQuantity.AnnualQuantityDataTable();

            var result = await ReservationService.Get<List<eCarService.Model.Reservation>>(new OrderSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                ExcludeDefaultValues = true
            });

            var user = await UserService.GetById<Model.User>(ServiceCredentials.UserId);

            parameters.Add(new ReportParameter("eCarServiceName", user.UserName));
            parameters.Add(new ReportParameter("quantitySum", result.Where(x => x.Date.Year == dtpYear.Value.Year).Count().ToString()));


            for (int i = 1; i <= 12; i++)
            {
                var row = tblQuantity.NewAnnualQuantityRow();
                row.Month = i;
                row.Quantity = result.Where(x => x.Date.Month == i && x.Date.Year == dtpYear.Value.Year).Count();
                tblQuantity.AddAnnualQuantityRow(row);

            }

            if (refresh)
            {
                reportViewer1.LocalReport.DataSources.RemoveAt(0);
            }

            ReportDataSource dataSource = new ReportDataSource();

            dataSource.Name = "dsAnnualQuantity";
            dataSource.Value = tblQuantity;

            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

        }
        private void btnGraphic_Click_1(object sender, EventArgs e)
        {
            Form form = new frmYearlyQuantityReport();
            form.ShowDialog();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            loadReport(true);

        }

        private void frmAnnualQuantityReport_Load(object sender, EventArgs e)
        {
            loadReport();

        }
    }
}
