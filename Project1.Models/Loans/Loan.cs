using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Models.Loans
{
    public class Loan
    {

        public static decimal LoanInterestRate = 0.25M;

        [Display(Name = "Loan ID")]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Pricipal Amount")]
        public decimal Principal { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Current Balance")]
        public decimal Balance { get; set; }
        public bool PaidOff { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        public List<LoanPayment> Payments { get; set; }
    }
}
