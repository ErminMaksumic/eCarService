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

namespace eProdajaService.WinUI.Ratings
{
    public partial class frmRatingList : Form
    {
        private readonly APIService RatingService = new APIService("Rating");

        public frmRatingList()
        {
            InitializeComponent();
        }

        private void frmRatingList_Load(object sender, EventArgs e)
        {
            loadRatings();
            loadAverageRate();
        }

        private async void loadAverageRate()
        {
            var result = await RatingService.Get<List<eCarService.Model.Rating>>();

            lblAverageRating.Text = result.Average(x => x.Rate).ToString();
        }

        private async void loadRatings()
        {
            RatingSearchObject search = new RatingSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId
            };

            var result = await RatingService.Get<List<eCarService.Model.Rating>>(search);
            dgvRatingList.AutoGenerateColumns = false;
            dgvRatingList.DataSource = result;
        }
    }
}
