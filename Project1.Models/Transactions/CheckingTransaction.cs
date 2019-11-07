using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.Transactions
{
    public class CheckingTransaction : Transaction 
    {
        public int CheckingAccountID { get; set; }
    }
}
