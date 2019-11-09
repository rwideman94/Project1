using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class TransactionsVM
    {
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime End { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
