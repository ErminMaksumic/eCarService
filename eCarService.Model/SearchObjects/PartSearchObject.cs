using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class PartSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public bool InclCarService { get; set; }
        public int CarServiceId { get; set; }

    }
}
