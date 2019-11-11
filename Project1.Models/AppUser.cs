using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Project1.Models.Accts;
using Project1.Models.Loans;

namespace Project1.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        public string City { get; set; }

        [StringLength(maximumLength: 2)]
        public string State { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Current Overdraft")]
        public decimal Overdraft { get; set; }

        public List<BusinessAccount> BAccounts { get; set; }
        public List<CheckingAccount> CAccounts { get; set; }
        public List<Loan> Loans { get; set; }
        public List<TermDeposit> TermDeposits { get; set; }
    }
}