using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class MyProfileUpdateRequest
    {
        [Required(AllowEmptyStrings = false), MinLength(5)]

        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
        public byte[] Image { get; set; }

    }
}
