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
    public class BusinessRepo : IBusinessRepo
    {

        private Project1DbContext _context;

        public BusinessRepo(Project1DbContext ctx)
        {
            _context = ctx;
        }

        public async Task<bool> Add(BusinessAccount businessAccount)
        {
            _context.Add(businessAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Close(int id)
        {
            var businessAccount = await _context.BusinessAccounts.FindAsync(id);
            businessAccount.IsClosed = true;
            _context.Update(businessAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool BusinessAccountExists(int id)
        {
            return _context.BusinessAccounts.Any(e => e.Id == id);
        }

        public async Task<bool> Deposit(int id, decimal amount)
        {
            BusinessAccount businessAccount = await _context.BusinessAccounts.FindAsync(id);
            businessAccount.Balance += amount;
            _context.Update(businessAccount);
            BusinessTransaction businessTransaction = new BusinessTransaction { BusinessAccountID = id, Amount = amount, TransTime = DateTime.Now, Details = $"Deposit of ${amount}" };
            _context.Add(businessTransaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BusinessAccount>> Get()
        {
            return await _context.BusinessAccounts.ToListAsync();
        }

        public async Task<List<BusinessAccount>> Get(string userId)
        {
            return await _context.BusinessAccounts.Where(b => b.AppUserId == userId).ToListAsync();
        }

        public async Task<BusinessAccount> Get(int? id)
        {
            return await _context.BusinessAccounts.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> Withdraw(int id, decimal amount)
        {
            BusinessAccount businessAccount = await _context.BusinessAccounts.FindAsync(id);
            businessAccount.Balance -= amount;
            _context.Update(businessAccount);
            BusinessTransaction businessTransaction = new BusinessTransaction { BusinessAccountID = id, Amount = amount, TransTime = DateTime.Now, Details = $"Withdrawl of ${amount}" };
            _context.Add(businessTransaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Transfer(int idFrom, int idTo, decimal amount)
        {
            try
            {
                BusinessAccount bAccountFrom = await _context.BusinessAccounts.FindAsync(idFrom);
                BusinessAccount bAccountTo = await _context.BusinessAccounts.FindAsync(idTo);

                bAccountFrom.Balance -= amount;
                bAccountTo.Balance += amount;

                _context.Update(bAccountFrom);
                _context.Update(bAccountTo);
                BusinessTransaction businessTransactionFrom = new BusinessTransaction { BusinessAccountID = idFrom, Amount = amount, TransTime = DateTime.Now, Details = $"Transfer of ${amount} to account #{idTo}" };
                _context.Add(businessTransactionFrom);
                BusinessTransaction businessTransactionTo = new BusinessTransaction { BusinessAccountID = idTo, Amount = amount, TransTime = DateTime.Now, Details = $"Transfer of ${amount} from account #{idFrom}" };
                _context.Add(businessTransactionTo);
                await _context.SaveChangesAsync();
                return true;
            } catch
            {
                throw;
            }
        }

        public async Task<List<BusinessTransaction>> GetTransactions()
        {
            return await _context.BusinessTransactions.ToListAsync();
        }
    }
}
