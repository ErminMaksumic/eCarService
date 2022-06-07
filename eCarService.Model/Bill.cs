using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Model
{
    public class Bill
    {
        public int BillId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }    }
}
