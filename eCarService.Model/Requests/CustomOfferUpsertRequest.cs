using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CustomOfferUpsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

        public int? CarServiceId { get; set; }
    }
}
