using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBankers.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string Sender { get; set; }

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string Receiver { get; set; }
        public decimal Amount { get; set; }
    }
}
