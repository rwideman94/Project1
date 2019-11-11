using Project1.Models.BusinessLayer;
using Project1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly TestDbContext _context;
        private readonly UserBL UBL;

        public UserRepo(TestDbContext ctx)
        {
            _context = ctx;
            UBL = new UserBL();
        }

        public AppUser Get(string userId)
        {
            return  _context.AppUsers.FirstOrDefault(u => u.Id == userId);
        }

        public List<OverdraftPaymentRecord> GetPayments(string userId)
        {
            return _context.OverdraftPayments.Where(o => o.AppUserId == userId).ToList();
        }

        public async Task<bool> OverdraftPayment(AppUser user, decimal amount)
        {
            UBL.OverdraftPayment(user, amount);
            _context.Add(new OverdraftPaymentRecord { 
                Amount = amount, 
                AppUserId = user.Id, 
                PaymentTime = DateTime.Now, 
                Details = $"Payment of { amount }" });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> OverdraftPayment(AppUser user, decimal amount, int accountID)
        {
            UBL.OverdraftPayment(user, amount);
            _context.Add(new OverdraftPaymentRecord { 
                Amount = amount, 
                AppUserId = user.Id, 
                PaymentTime = DateTime.Now, 
                Details = $"Payment of {amount} from account #{accountID}" });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
