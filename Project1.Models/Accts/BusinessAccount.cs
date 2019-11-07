using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.Accts
{
    public class BusinessAccount : Account
    {
        public decimal OverdraftFees { get; set; }
        public List<BusinessTransaction> Transactions { get; set; }
}
}
