using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class BasicUserUpdateRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress(), MaxLength(25)]
        public string Email { get; set; }
    }
}
