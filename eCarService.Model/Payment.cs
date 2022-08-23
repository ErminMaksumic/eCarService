﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionId { get; set; }
        public string FullName { get; set; }

    }
}
