using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public int? OfferId { get; set; }
        public int? UserId { get; set; }

        public virtual Offer? Offer { get; set; }
        public virtual User? User { get; set; }
    }
}
