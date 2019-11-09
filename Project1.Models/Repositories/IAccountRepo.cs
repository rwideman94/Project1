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
        Task<bool> Add(BusinessAccount account);
        Task<bool> Add(CheckingAccount account);
        bool BusinessAccountExists(int id);
        bool CheckingAccountExists(int id);
        Task<bool> Close(Account account);
        Task<bool> Deposit(Account account, decimal amount);
        Task<bool> Deposit(BusinessAccount account, decimal amount);
        Task<List<Account>> GetBusiness();
        Task<Account> GetBusiness(int? id);
        Task<List<Account>> GetBusiness(string userId);
        Task<List<Account>> GetChecking();
        Task<Account> GetChecking(int? id);
        Task<List<Account>> GetChecking(string userId);
        Task<List<Transaction>> GetBusinessTransactions();
        Task<List<Transaction>> GetCheckingTransactions();
        Task<bool> Withdraw(Account account, decimal amount);
        Task<bool> Withdraw(BusinessAccount account, decimal amount);
        Task<bool> Transfer(Account acctFrom, Account acctTo, decimal amount);
    }
}
