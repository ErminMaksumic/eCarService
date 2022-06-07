using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model
{
    public class AdditionalService
    {
        public int AdditionalServiceId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal? Price { get; set; }
    }
}
