using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class WithdrawlVM : IValidatableObject
    {
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01,Double.MaxValue, ErrorMessage="You can't withdraw an amount of 0 or less.")]
        [Display(Name ="Withdrawl Amount")]
        public decimal Amount { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        //public string AccountUserId { get; set; }
        //[Compare(nameof(AccountUserId))]
        //public string UserID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Amount > Balance && AccountType == "Checking")
            {
                yield return
                  new ValidationResult(errorMessage: "You can't withdraw more than a checking account contains.",
                                       memberNames: new[] { "Amount" });
            }
        }
    }
}
