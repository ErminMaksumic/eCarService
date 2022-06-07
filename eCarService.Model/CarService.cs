using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class CarService
    {
        public int CarServiceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }


    }
}
