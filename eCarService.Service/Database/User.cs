using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class User
    {
        public User()
        {
            CarServices = new HashSet<CarService>();
            Ratings = new HashSet<Rating>();
            Reservations = new HashSet<Reservation>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<CarService> CarServices { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
