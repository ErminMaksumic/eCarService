using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class OfferSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Include { get; set; }
    }
}
