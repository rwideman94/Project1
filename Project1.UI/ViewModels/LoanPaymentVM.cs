﻿using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class LoanPaymentVM : IValidatableObject
    {
        public List<Account> Accounts { get; set; }
        public bool PaidOff { get; set; }
        [Display(Name = "Pay from Account?")]
        public bool PaymentFromAccount { get; set; }
        public decimal Amount { get; set; }
        public int AccountID { get; set; }
        public decimal AccountBalance { get; set; }
        [Display(Name = "Current Loan Balance")]
        public decimal LoanBalance { get; set; }
        //public string LoanUserId { get; set; }
        //[Compare(nameof(LoanUserId))]
        //public string UserID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PaidOff)
            {
                yield return
                  new ValidationResult(errorMessage: "This Loan is paid off already.",
                                       memberNames: new[] { "PaidOff" });
            }
            //if (AccountBalance < Amount)
            //{
            //    yield return
            //      new ValidationResult(errorMessage: "An account can't go negative in paying off a loan.",
            //                           memberNames: new[] { "Amount" });
            //}
            if (LoanBalance < Amount)
            {
                yield return
                  new ValidationResult(errorMessage: "You don't owe that much.",
                                       memberNames: new[] { "Amount" });
            }
        }
    }
}
