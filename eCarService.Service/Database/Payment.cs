using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Payment
    {
        public Payment()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PaymentId { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }


        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}