using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class WithdrawlVM
    {
        [Required]
        [DataType(DataType.Currency)]
        [Range(0,Double.MaxValue, ErrorMessage="You can't withdraw a negative amount.")]
        [Display(Name ="Withdrawl Amount")]
        public decimal Amount { get; set; }
    }
}
