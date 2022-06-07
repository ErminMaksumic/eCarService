
using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarBrandUpsertRequest
    {
        public string Name { get; set; }
        public int? CarServiceId { get; set; }

    }
}
