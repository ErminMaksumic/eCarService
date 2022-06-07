using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarServiceInsertRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }



    }
}
