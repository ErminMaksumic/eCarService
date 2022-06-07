using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class RatingUpsertRequest
    {
        [Required]
        public int? Rate { get; set; }
        public string Comment { get; set; }
    }
}
