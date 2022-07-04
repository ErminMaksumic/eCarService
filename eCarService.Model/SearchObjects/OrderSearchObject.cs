using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class OrderSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
