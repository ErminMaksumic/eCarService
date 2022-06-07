using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Part
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? CarServiceId { get; set; }
    }
}
