using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Project1.Models.BusinessLayer;

namespace Project1.Models.Repositories
{
    public class TermDepositRepo : ITermDepositRepo
    {

        private readonly TestDbContext _context;
        private readonly TermDepositBL TDBL;

        public TermDepositRepo(TestDbContext ctx)
        {
            _context = ctx;
            TDBL = new TermDepositBL();
        }

        public async Task<bool> Add(TermDeposit termDeposit)
        {
            _context.Add(termDeposit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TermDeposit>> Get()
        {
            return await _context.TermDeposits.ToListAsync();
        }

        public async Task<TermDeposit> Get(int? id)
        {
            return await _context.TermDeposits.FirstOrDefaultAsync(td => td.Id == id);
        }

        public async Task<List<TermDeposit>> Get(string userId)
        {
            return await _context.TermDeposits.Where(td => td.AppUserId == userId).ToListAsync();
        }

        public bool TermDepositExists(int? id)
        {
            return _context.TermDeposits.Any(td => td.Id == id);
        }

        public async Task<bool> Withdraw(TermDeposit termDeposit)
        {
            TDBL.Withdraw(termDeposit);
            _context.Update(termDeposit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
