using Project1.Models.Accts;
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
        [Display(Name = "Account to pay from")]
        public bool PaymentFromAccount { get; set; }
        public decimal Amount { get; set; }
        public int AccountID { get; set; }
        public decimal AccountBalance { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PaidOff)
            {
                yield return
                  new ValidationResult(errorMessage: "This Loan is paid off already.",
                                       memberNames: new[] { "PaidOff" });
            }
            if (AccountBalance < Amount)
            {
                yield return
                  new ValidationResult(errorMessage: "An account can't go negative in paying off a loan.",
                                       memberNames: new[] { "Amount" });
            }
        }
    }
}
