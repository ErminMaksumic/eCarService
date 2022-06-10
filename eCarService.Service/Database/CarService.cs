using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class CarService
    {
        public CarService()
        {
            CarBrands = new HashSet<CarBrand>();
            CustomOfferRequests = new HashSet<CustomOfferRequest>();
            Offers = new HashSet<Offer>();
            Parts = new HashSet<Part>();
        }

        public int CarServiceId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? DateCreated { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CarBrand> CarBrands { get; set; }
        public virtual ICollection<CustomOfferRequest> CustomOfferRequests { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
