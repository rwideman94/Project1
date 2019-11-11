using Project1.Models.Loans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public interface ILoanRepo
    {
        Task<List<Loan>> Get();
        Task<Loan> Get(int? id);
        Task<List<Loan>> Get(string userId);
        Task<bool> Add(Loan loan);
        Task<bool> Pay(Loan loan, decimal amount);
        bool LoanExists(int? id);
    }
}
