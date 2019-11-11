using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public interface ITermDepositRepo
    {
        Task<List<TermDeposit>> Get();
        Task<TermDeposit> Get(int? id);
        Task<List<TermDeposit>> Get(string userId);
        Task<bool> Add(TermDeposit termDeposit);
        Task<bool> Withdraw(TermDeposit termDeposit);
        bool TermDepositExists(int? id);
    }
}
