using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Models.Accts
{
    public abstract class Account
    {
        [Display(Name = "Account ID")]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(maximumLength:20,MinimumLength = 5)]
        [Display(Name = "Account Nickname")]
        public string NickName { get; set; }
        public decimal Balance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
        //public bool isActive { get; set; } = true;
        public bool IsClosed { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime DateCreated { get; set; }
        //public List<Transaction> transactions = new List<Transaction>();

    }
}
