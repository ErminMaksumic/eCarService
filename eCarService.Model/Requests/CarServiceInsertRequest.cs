using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarServiceInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }

        [Required(AllowEmptyStrings = false), Phone]
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }



    }
}
