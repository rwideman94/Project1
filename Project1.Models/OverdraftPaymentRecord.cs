using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models
{
    public class OverdraftPaymentRecord
    {
        public int Id { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
        public string AppUserId { get; set; }
    }
}
