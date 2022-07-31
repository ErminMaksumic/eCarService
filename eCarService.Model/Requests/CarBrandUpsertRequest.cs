
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CarBrandUpsertRequest
    {
        [Required (AllowEmptyStrings = false), MaxLength(6)]
        public string Name { get; set; }
        public int? CarServiceId { get; set; }

    }
}
