using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.Transactions
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransTime { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
        public int AccountID { get; set; }
    }
}
