using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class PartUpsertRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int CarServiceId { get; set; }
    }
}
