using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [MinLength(4)]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }


    }
}
