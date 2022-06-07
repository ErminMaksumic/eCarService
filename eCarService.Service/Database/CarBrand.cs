using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class CarBrand
    {
        public CarBrand()
        {
            CarBrandOffers = new HashSet<CarBrandOffer>();
        }

        public int CarBrandId { get; set; }
        public string Name { get; set; } = null!;
        public int? CarServiceId { get; set; }

        public virtual CarService? CarService { get; set; }
        public virtual ICollection<CarBrandOffer> CarBrandOffers { get; set; }
    }
}
