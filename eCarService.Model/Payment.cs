using System;
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
        public int? ReservationId { get; set; }
        public int? BillId { get; set; }
    }
}
