using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class ReservationInsertRequest
    {
        public string Status { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public int CarBrandId { get; set; }
        public int? OfferId { get; set; }
        public List<int> AdditionalServices { get; set; } = new List<int>();

    }
}
