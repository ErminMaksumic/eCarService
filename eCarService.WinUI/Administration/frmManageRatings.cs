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

namespace eProdajaService.WinUI.Administration
{
    public partial class frmManageRatings : Form
    {
        public APIService RatingService { get; set; } = new APIService("Rating");

        public frmManageRatings()
        {
            InitializeComponent();
        }

        private void frmManageRatings_Load(object sender, EventArgs e)
        {
            loadRatings();
        }

        private async void loadRatings()
        {
            RatingSearchObject search = new RatingSearchObject()
            {
                OfferName = txtSearch.Text
            };

            var result = await RatingService.Get<List<eCarService.Model.Rating>>(search);
            dgvRatings.AutoGenerateColumns = false;
            dgvRatings.DataSource = result;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            loadRatings();
        }

        private void frmManageRatings_Load_1(object sender, EventArgs e)
        {
            loadRatings();

        }

        private async void dgvRatings_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvRatings.Rows[e.RowIndex].DataBoundItem as eCarService.Model.Rating;

            if (e.ColumnIndex == dgvRatings.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                await RatingService.Delete<eCarService.Model.AdditionalService>(item.RatingId);

                loadRatings();

                MessageBox.Show($"Rating successfuly deleted!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
