using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Requests
{
    public class PaymentUpsertRequest
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }
    }
}
