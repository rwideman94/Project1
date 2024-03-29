﻿using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class DepositVM
    {
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01,Double.MaxValue, ErrorMessage= "You can't deposit an amount of 0 or less.")]
        [Display(Name = "Deposit Amount")]
        public decimal Amount { get; set; }
        //public string AccountUserId { get; set; }
        //[Compare(nameof(AccountUserId))]
        //public string UserID { get; set; }
    }
}
