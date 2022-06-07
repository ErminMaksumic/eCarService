using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class OfferPart
    {
        public int OfferPartId { get; set; }
        public int? PartId { get; set; }
        public int? OfferId { get; set; }
    }
}
