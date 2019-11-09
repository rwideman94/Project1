﻿using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class TransferVM
    {
        [Required]
        [DataType(DataType.Currency)]
        [Range(0, Double.MaxValue, ErrorMessage = "You can't transfer a negative amount.")]
        [Display(Name = "Transfer Amount")]
        public decimal Amount { get; set; }

        //Required]
        [Display(Name = "Account to transfer from")]
        public int AccountIDFrom { get; set; }

        [Required]
        [Display(Name = "Account to transfer to")]
        public int AccountIDTo { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
