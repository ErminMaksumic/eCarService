using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Part
    {
        public Part()
        {
            OfferParts = new HashSet<OfferPart>();
        }

        public int PartId { get; set; }
        public string Name { get; set; } = null!;
        public int? Quantity { get; set; }
        public int? CarServiceId { get; set; }

        public virtual CarService? CarService { get; set; }
        public virtual ICollection<OfferPart> OfferParts { get; set; }
    }
}
