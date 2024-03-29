﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCarService.Model.Requests
{
    public class ReservationInsertRequest
    {
        public string Status { get; set; }
        [MaxLength(30)]
        public string Note { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        public int CarBrandId { get; set; }
        public int? OfferId { get; set; }
        public List<int> AdditionalServices { get; set; } = new List<int>();
        public PaymentUpsertRequest Payment { get; set; }

    }
}
