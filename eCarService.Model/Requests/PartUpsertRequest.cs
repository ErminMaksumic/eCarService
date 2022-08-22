using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class PartUpsertRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(18)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int CarServiceId { get; set; }
    }
}
