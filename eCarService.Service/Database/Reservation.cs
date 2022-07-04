using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationsAdditionalServices = new HashSet<ReservationsAdditionalService>();
        }

        public int ReservationId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int? OfferId { get; set; }
        public int? PaymentId { get; set; }
        public int? CarBrandId { get; set; }

        public virtual CarBrand? CarBrand { get; set; }
        public virtual Offer? Offer { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<ReservationsAdditionalService> ReservationsAdditionalServices { get; set; }
    }
}
