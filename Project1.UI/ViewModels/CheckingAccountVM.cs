using Project1.Models.Accts;
using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class CheckingAccountVM
    {
        public Account Account { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
