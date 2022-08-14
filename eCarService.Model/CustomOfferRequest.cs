using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model
{
    public class CustomOfferRequest
    {
        public int CustomReqId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public int? CarServiceId { get; set; }

        public virtual User User { get; set; }
        public virtual string UserName => User.UserName;
    }
}
