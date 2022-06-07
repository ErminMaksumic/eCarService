using System;
using System.Collections.Generic;

namespace eCarService.Database
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public int? ReservationId { get; set; }
        public int? BillId { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Reservation? Reservation { get; set; }
    }
}
