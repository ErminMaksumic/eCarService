using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Offer
    {
        public Offer()
        {
            CarBrandOffers = new HashSet<CarBrandOffer>();
          //  OfferParts = new HashSet<OfferPart>();
           // Ratings = new HashSet<Rating>();
            //Reservations = new HashSet<Reservation>();
        }

        public int OfferId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public int? CarServiceId { get; set; }
        //public byte[]? Image { get; set; }

        public virtual CarService? CarService { get; set; }
        public virtual ICollection<CarBrandOffer> CarBrandOffers { get; set; }
        public virtual ICollection<OfferPart> OfferParts { get; set; }
       // public virtual ICollection<Rating> Ratings { get; set; }
       // public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
