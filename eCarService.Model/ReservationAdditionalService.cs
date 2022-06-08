using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model
{
    public class ReservationAdditionalService
    {
        public int ResAddServicesId { get; set; }
        public int ReservationId { get; set; }
        public int AdditionalServiceId { get; set; }
    }
}
