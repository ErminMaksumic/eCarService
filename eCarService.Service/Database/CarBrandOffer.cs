using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class CarBrandOffer
    {
        public int CarBrandOfferId { get; set; }
        public int? CarBrandId { get; set; }
        public int? OfferId { get; set; }

        public virtual CarBrand? CarBrand { get; set; }
        public virtual Offer? Offer { get; set; }
    }
}
