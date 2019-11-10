using Project1.Models.Accts;
using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public interface IAccountRepo
    {
        Task<bool> Add(Account account);
        bool AccountExists(int id);
        Task<bool> Close(Account account);
        Task<bool> Deposit(Account account, decimal amount);
        Task<List<Account>> Get();
        Task<Account> Get(int? id);
        Task<List<Account>> Get(string userId);
        Task<List<Transaction>> GetTransactions();
        Task<bool> Overdraft(AppUser user, Account account, decimal amount);
        Task<bool> Withdraw(Account account, decimal amount);
        Task<bool> Transfer(Account acctFrom, Account acctTo, decimal amount);

    }
}
