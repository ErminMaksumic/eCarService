using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public int? OfferId { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public string UserName => User?.UserName ?? string.Empty;

    }
}
