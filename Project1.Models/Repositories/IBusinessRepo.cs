using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models.Repositories
{
    public interface IBusinessRepo
    {
        Task<List<BusinessAccount>> Get();
        Task<BusinessAccount> Get(int? id);
        Task<bool> Add(BusinessAccount businessAccount);
        Task<bool> Close(int id);
        Task<bool> Deposit(int id, decimal amount);
        Task<bool> Withdraw(int id, decimal amount);
        bool BusinessAccountExists(int id);
        Task<bool> Transfer(int idFrom, int idTo, decimal amount);
    }
}
