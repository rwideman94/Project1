using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Project1.Models.Accts.Account> Accounts { get; set; }
        public IEnumerable<Project1.Models.Accts.Account> CheckingAccounts { get; set; }
        public IEnumerable<Project1.Models.Accts.Account> BusinessAccoutns { get; set; }
    }
}
