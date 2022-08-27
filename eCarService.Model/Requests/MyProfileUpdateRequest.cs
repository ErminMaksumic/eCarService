using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class MyProfileUpdateRequest
    {
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string PasswordConfirmation { get; set; }
        public byte[] Image { get; set; }

    }
}
