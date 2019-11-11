using Project1.Models.Accts;
using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class AccountVM
    {
        
        public Account Account { get; set; }
        public string AccountUserId { get; set; }
        //[Compare(nameof(AccountUserId))]
        //public string UserID { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
