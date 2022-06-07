using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class ReservationsAdditionalService
    {
        public int ResAddServicesId { get; set; }
        public int ReservationId { get; set; }
        public int AdditionalServiceId { get; set; }

        public virtual AdditionalService AdditionalService { get; set; } = null!;
        public virtual Reservation Reservation { get; set; } = null!;
    }
}
