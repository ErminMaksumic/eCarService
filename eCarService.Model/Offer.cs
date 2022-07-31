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
        public byte[] Image { get; set; }
        public int? CarServiceId { get; set; }
        public virtual ICollection<CarBrandOffer> CarBrandOffers { get; set; }
        public virtual ICollection<OfferPart> OfferParts { get; set; }

        public List<Part> Parts { get; set; }
        public List<CarBrand> CarBrands { get; set; }

        public string PartNames => String.Join(", ", Parts?.Take(3).Select(x => x?.Name));
        public string CarBrandNames => String.Join(", ", CarBrands?.Take(3).Select(x => x?.Name));

    }
}
