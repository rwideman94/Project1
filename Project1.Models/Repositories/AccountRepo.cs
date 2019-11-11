using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models.Accts;
using Project1.Models.BusinessLayer;
using Project1.Models.Transactions;

namespace Project1.Models.Repositories
{
    public class AccountRepo : IAccountRepo
    {

        private readonly TestDbContext _context;
        private readonly AccountBL ABL;

        public AccountRepo(TestDbContext ctx)
        {
            _context = ctx;
            ABL = new AccountBL();
        }

        public async Task<bool> Add(Account account)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public void AddTransaction(int id, decimal amount, string details)
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

        public bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        public async Task<bool> Close(Account account)
        {
            ABL.Close(account);
            _context.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deposit(Account account, decimal amount)
        {
            ABL.Deposit(account, amount);
            _context.Update(account);
            AddTransaction(account.Id, amount, $"Deposit of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Account>> Get()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> Get(int? id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<List<Account>> Get(string userId)
        {
            return await _context.Accounts.Where(b => b.AppUserId == userId).ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<bool> LoanWithdrawl(Account account, decimal amount, int loanID)
        {
            ABL.Withdraw(account, amount);
            _context.Update(account);
            AddTransaction(account.Id, amount, $"PAyment of ${amount} on Loan #{loanID}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TDDeposit(Account account, decimal amount, int tdID)
        {
            ABL.Deposit(account, amount);
            _context.Update(account);
            AddTransaction(account.Id, amount, $"Deposit of ${amount} from Term Deposit #{tdID}");
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Transfer(Account acctFrom, Account acctTo, decimal amount)
        {
            try
            {
                ABL.Transfer(acctFrom, acctTo, amount);

                _context.Update(acctFrom);
                _context.Update(acctTo);
                AddTransaction(acctTo.Id, amount, $"Transfer of ${amount} to {acctTo.AccountType} account #{acctTo.Id}");
                AddTransaction(acctTo.Id, amount, $"Transfer of ${amount} from {acctFrom.AccountType} #{acctFrom.Id}");
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Withdraw(Account account, decimal amount)
        {
            ABL.Withdraw(account, amount);
            _context.Update(account);
            AddTransaction(account.Id, amount, $"Withdrawl of ${amount}");
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Overdraft(AppUser user, Account account, decimal amount)
        {
            ABL.Withdraw(account, amount);
            var overdraft = ABL.Overdraft(user, account);
            AddTransaction(account.Id, amount, $"Withdrawl of ${amount} (Overdraft fee of {overdraft} charged to your profile)");
            _context.Update(account);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
