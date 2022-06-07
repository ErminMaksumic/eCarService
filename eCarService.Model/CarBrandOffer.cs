using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model
{
    public class CarBrandOffer
    {
        public int CarBrandOfferId { get; set; }
        public int? CarBrandId { get; set; }
        public int? OfferId { get; set; }
        public virtual CarBrand CarBrand { get; set; }

    }
}
