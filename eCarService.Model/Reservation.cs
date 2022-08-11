using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int? OfferId { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual CarBrand CarBrand { get; set; }
        public string BrandName => CarBrand?.Name;

        public string OfferName => Offer?.Name;
        public virtual ICollection<ReservationAdditionalService> ReservationAdditionalService { get; set; }


    }
}
