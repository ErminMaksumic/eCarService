using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class OfferPart
    {
        public int OfferPartId { get; set; }
        public int OfferId { get; set; }
        public int PartId { get; set; }

        public virtual Offer Offer { get; set; } = null!;
        public virtual Part Part { get; set; } = null!;
    }
}
