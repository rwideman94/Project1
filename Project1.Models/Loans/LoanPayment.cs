using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Models.Loans
{
    public class LoanPayment
    {
        public int Id { get; set; }
        public int LoanID { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Amount Paid")]
        public decimal Amount { get; set; }
        [Display(Name = "Payment Time")]
        public DateTime PaymentTime { get; set; }
        [Display(Name = "Payment Details")]
        public string Details { get; set; }
    }
}
