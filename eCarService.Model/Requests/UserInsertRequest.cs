using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]

        [EmailAddress(), MaxLength(25)]
        public string Email { get; set; }

        [MinLength(4), MaxLength(15)]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false), MinLength(5), MaxLength(20)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string PasswordConfirmation { get; set; }
        public int? RoleId { get; set; }
        [Required]
        public byte[] Image { get; set; }




    }
}
