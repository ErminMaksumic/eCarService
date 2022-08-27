using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class AdditionalServiceUpsertRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false), Range(1, 200)]
        public decimal? Price { get; set; }
    }
}
