using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.Transactions
{
    public abstract class Transaction
    {
        public DateTime TransTime { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }

        public Transaction()
        {
            TransTime = DateTime.Now;
        }
    }
}
