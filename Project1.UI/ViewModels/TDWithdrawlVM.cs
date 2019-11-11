using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class TDWithdrawlVM : IValidatableObject
    {
        public List<Account> Accounts { get; set; }
        [Display(Name="Withdraw to an active account?")]
        public bool WithdrawlToAccount { get; set; }
        [Display(Name = "Account to transfer funds to")]
        public int AccountID { get; set; }
        public bool Withdrawn { get; set; }
        public DateTime maturityDate { get; set; }
        //public string TermDepositUserId { get; set; }
        //[Compare(nameof(TermDepositUserId))]
        //public string UserID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Withdrawn)
            {
                yield return
                  new ValidationResult(errorMessage: "You can't withdraw from a term deposit twice.",
                                       memberNames: new[] { "Withdrawn" });
            }
        }
    }
}
