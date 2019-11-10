using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Models.Accts
{
    public class Account
    {
        [Display(Name = "Account ID")]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [Required]
        [StringLength(maximumLength:20,MinimumLength = 5)]
        [Display(Name = "Account Nickname")]
        public string NickName { get; set; }
        public decimal Balance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
        public bool IsClosed { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Account Type")]
        public string AccountType { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public static decimal BusinessInterestRate = .25M;
        public static decimal CheckingInterestRate = .01M;
    }
}
