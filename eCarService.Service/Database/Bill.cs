using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Bill
    {
        public Bill()
        {
            Payments = new HashSet<Payment>();
        }

        public int BillId { get; set; }
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
