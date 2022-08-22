using eCarService.DesktopApp;
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
        }

        private async void loadRatings()
        {
            var result = await RatingService.Get<List<eCarService.Model.Rating>>(new RatingSearchObject()
            {
                CarServiceId = ServiceCredentials.ServiceId,
                OfferName = txtSearch.Text
            });

            lblAverageRating.Text = Math.Round((double)result.Average(x => x.Rate),2).ToString();

            dgvRatingList.AutoGenerateColumns = false;
            dgvRatingList.DataSource = result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadRatings();
        }

     
    }
}
