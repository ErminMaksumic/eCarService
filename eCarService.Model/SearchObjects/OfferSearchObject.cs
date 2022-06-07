using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class OfferSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public int CarServiceId { get; set; }
    }
}
