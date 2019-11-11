using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.BusinessLayer
{
    public class TermDepositBL
    {
        public void Withdraw(TermDeposit termDeposit)
        {
            termDeposit.Withdrawn = true;
            termDeposit.WithdrawlDate = DateTime.Today;
        }
    }
}
