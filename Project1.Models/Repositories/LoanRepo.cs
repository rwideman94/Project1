using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project1.Models.Loans;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project1.Models.BusinessLayer;

namespace Project1.Models.Repositories
{
    public class LoanRepo : ILoanRepo
    {

        private readonly TestDbContext _context;
        private readonly LoanBL loanBL;

        public LoanRepo(TestDbContext ctx)
        {
            _context = ctx;
            loanBL = new LoanBL();
        }

        public async Task<bool> Add(Loan loan)
        {
            _context.Add(loan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Loan>> Get()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> Get(int? id)
        {
            return await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Loan>> Get(string userId)
        {
            return await _context.Loans.Where(l => l.AppUserId == userId).ToListAsync();
        }

        public bool LoanExists(int? id)
        {
            return _context.Loans.Any(l => l.Id == id);
        }

        public async Task<bool> Pay(Loan loan, decimal amount)
        {
            loanBL.Payment(loan, amount);
            _context.Update(loan);
            LoanPayment lPayment = new LoanPayment
            {
                Amount = amount,
                LoanID = loan.Id,
                PaymentTime = DateTime.Now,
                Details = $"Payment of {amount}, {loan.Balance} remaining"
            };
            _context.Add(lPayment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
