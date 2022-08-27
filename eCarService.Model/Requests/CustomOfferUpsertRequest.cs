using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class CustomOfferUpsertRequest
    {
        [MaxLength(15), Required]
        public string Name { get; set; }
        [MaxLength(30), Required]
        public string Description { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

        public int? CarServiceId { get; set; }
    }
}
