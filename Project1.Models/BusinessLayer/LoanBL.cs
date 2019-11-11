using Project1.Models.Loans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.BusinessLayer
{
    public class LoanBL
    {
        public void Payment(Loan loan, decimal amount)
        {
            loan.Balance -= amount;
        }
    }
}
