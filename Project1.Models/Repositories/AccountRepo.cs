using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models.Accts;
using Project1.Models.Transactions;

namespace Project1.Models.Repositories
{
    public class AccountRepo : IAccountRepo
    {

        private TestDbContext _context;

        public AccountRepo(TestDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<bool> Add(BusinessAccount businessAccount)
        {
            _context.Add(businessAccount);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Add(CheckingAccount checkingAccount)
        {
            _context.Add(checkingAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public void AddBusinessTransaction(int id, decimal amount, string details)
        {
            Transaction transaction = new Transaction
            {
                AccountID = id,
                Amount = amount,
                TransTime = DateTime.Now,
                Details = details
            };
            _context.Add(transaction);
        }
        public void AddCheckingTransaction(int id, decimal amount, string details)
        {
            Transaction transaction = new Transaction
            {
                AccountID = id,
                Amount = amount,
                TransTime = DateTime.Now,
                Details = details
            };
            _context.Add(transaction);
        }

        public bool BusinessAccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
        public bool CheckingAccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        public async Task<bool> Close(Account account)
        {
            account.IsClosed = true;
            _context.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deposit(BusinessAccount account, decimal amount)
        {
            account.Balance += amount;
            _context.Update(account);
            AddBusinessTransaction(account.Id, amount, $"Deposit of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deposit(Account account, decimal amount)
        {
            account.Balance += amount;
            _context.Update(account);
            AddCheckingTransaction(account.Id, amount, $"Deposit of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Account>> GetBusiness()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetBusiness(int? id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<List<Account>> GetBusiness(string userId)
        {
            return await _context.Accounts.Where(b => b.AppUserId == userId).ToListAsync();
        }
        public async Task<List<Transaction>> GetBusinessTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Account>> GetChecking()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetChecking(int? id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<List<Account>> GetChecking(string userId)
        {
            return await _context.Accounts.Where(b => b.AppUserId == userId).ToListAsync();
        }
        public async Task<List<Transaction>> GetCheckingTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<bool> Transfer(Account acctFrom, Account acctTo, decimal amount)
        {
            try
            {
                acctFrom.Balance -= amount;
                acctTo.Balance += amount;

                _context.Update(acctFrom);
                _context.Update(acctTo);
                if (acctFrom is BusinessAccount)
                {
                    //AddBusinessTransaction(acctTo.Id, amount, $"Transfer of ${amount} to {acctTo.Type} account #{acctTo.Id}");
                }
                else
                {
                    //AddCheckingTransaction(acctTo.Id, amount, $"Transfer of ${amount} to {acctTo.Type} account #{acctTo.Id}");
                }

                if (acctFrom is BusinessAccount)
                {
                    //AddBusinessTransaction(acctTo.Id, amount, $"Transfer of ${amount} from {acctFrom.Type} #{acctFrom.Id}");
                }
                else
                {
                    //AddCheckingTransaction(acctTo.Id, amount, $"Transfer of ${amount} from {acctFrom.Type} #{acctFrom.Id}");
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Withdraw(BusinessAccount account, decimal amount)
        {
            account.Balance -= amount;
            _context.Update(account);
            AddBusinessTransaction(account.Id, amount, $"Withdrawl of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Withdraw(Account account, decimal amount)
        {
            account.Balance -= amount;
            _context.Update(account);
            AddCheckingTransaction(account.Id, amount, $"Withdrawl of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }





    }
}
