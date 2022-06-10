using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class CustomOfferRequest
    {
        public int CustomReqId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public int? CarServiceId { get; set; }

        public virtual CarService? CarService { get; set; }
        public virtual User? User { get; set; }
    }
}
