using Project1.Models.Loans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.UI.ViewModels
{
    public class LoanVM
    {
        public Loan Loan { get; set; }
        public List<LoanPayment> Payments { get; set; }
        //public string LoanUserId { get; set; }
        //[Compare(nameof(LoanUserId))]
        //public string UserID { get; set; }
    }
}
