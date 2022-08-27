using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarServiceUpdateRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(15)]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
