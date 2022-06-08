using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IncludeRoles { get; set; }
    }
}
