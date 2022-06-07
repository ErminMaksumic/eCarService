using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class CarServiceSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }

    }
}
