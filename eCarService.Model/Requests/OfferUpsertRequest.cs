using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class OfferUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int? CarServiceId { get; set; }
        public byte[] Image { get; set; }

        public List<int> Brands { get; set; } = new List<int>();
        public List<int> Parts { get; set; } = new List<int>();

    }
}
