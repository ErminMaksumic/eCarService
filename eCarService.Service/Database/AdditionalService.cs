using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class AdditionalService
    {
        public AdditionalService()
        {
            ReservationsAdditionalServices = new HashSet<ReservationsAdditionalService>();
        }

        public int AdditionalServiceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ReservationsAdditionalService> ReservationsAdditionalServices { get; set; }
    }
}
