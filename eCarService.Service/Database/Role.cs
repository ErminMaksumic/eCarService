using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string? Name { get; set; }
        public int? Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
