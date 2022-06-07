using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarServiceUpdateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
