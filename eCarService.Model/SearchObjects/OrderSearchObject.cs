using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class OrderSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public DateTime From { get; set; } = DateTime.Now.AddYears(-1); 
        public DateTime To { get; set; } = DateTime.Now;
        public string Include { get; set; }
        public bool ExcludeDefaultValues { get; set; } = false;
    }
}
