using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class OverdraftPaymentVM
    {
        public List<Account> Accounts { get; set; }
        [Display(Name = "Pay from an active account?")]
        public bool PaymentFromAccount { get; set; }
        [Display(Name = "Payment Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Account to pay from")]
        public int AccountID { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal OverdraftBalance { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AccountBalance < Amount)
            {
                yield return
                  new ValidationResult(errorMessage: "An account can't go negative in paying off a loan.",
                                       memberNames: new[] { "Amount" });
            }
            if (OverdraftBalance < Amount)
            {
                yield return
                  new ValidationResult(errorMessage: "You don't owe that much.",
                                       memberNames: new[] { "Amount" });
            }
        }
    }
}
