using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class RatingUpsertRequest
    {
        [Required, Range(1,5)]
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }

    }
}
