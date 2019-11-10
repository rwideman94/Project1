using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models.BusinessLayer
{
    public class AccountBL
    {
        public void Deposit(Account account, decimal amount)
        {
            account.Balance += amount;
        }

        public void Withdraw(Account account, decimal amount)
        {
            account.Balance -= amount;
        }

        public decimal Overdraft (AppUser user, Account account)
        {
            decimal overdraft = account.Balance*account.InterestRate;
            user.Overdraft += overdraft;
            return overdraft;
        }

        public void Transfer(Account accountFrom, Account accountTo, decimal amount)
        {
            accountFrom.Balance -= amount;
            accountTo.Balance += amount;
        }

        public void Close(Account account)
        {
            account.IsClosed = true;
        }
    }
}
