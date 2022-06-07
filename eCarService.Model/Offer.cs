using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public int? CarServiceId { get; set; }
        public virtual ICollection<CarBrandOffer> CarBrandOffers { get; set; }
        public virtual ICollection<OfferPart> OfferParts { get; set; }
    }
}
