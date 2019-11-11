using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Models
{
    public class TermDeposit
    {

        public static decimal TDInterestRate = 0.05M;

        [Display(Name = "Term Deposit ID")]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Deposit Amount")]
        [Range(0.01,Double.MaxValue,ErrorMessage ="You must deposit a positive amount.")]
        public decimal Amount { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Withdrawl Amount")]
        public decimal WithdrawlAmount { get; set; }
        [Display(Name = "Term Years")]
        [Range(1, 10, ErrorMessage = "Please choose between 1 to 10 years.")]
        public int TermYears { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Deposit Date")]
        public DateTime DateCreated { get; set; }
        public bool Withdrawn { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Withdrawl Date")]
        public DateTime WithdrawlDate { get; set; }
    }
}