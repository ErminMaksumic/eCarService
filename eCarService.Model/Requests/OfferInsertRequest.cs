using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class OfferInsertRequest
    {
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int? CarServiceId { get; set; }
        //public byte[] Image { get; set; }

        public List<int> Brands { get; set; } = new List<int>();

    }
}
