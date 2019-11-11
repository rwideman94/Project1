using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public interface IUserRepo
    {
        Task<bool> OverdraftPayment(AppUser user, decimal amount);
        Task<bool> OverdraftPayment(AppUser user, decimal amount, int accountID);
        List<OverdraftPaymentRecord> GetPayments(string userId);
        AppUser Get(string userId);
    }
}
