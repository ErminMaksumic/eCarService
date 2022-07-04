using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class RatingSearchObject : BaseSearchObject
    {
        public int UserId { get; set; }
        public string OfferName { get; set; }
    }
}
