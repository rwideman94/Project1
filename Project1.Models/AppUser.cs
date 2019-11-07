using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Project1.Models.Accts;

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

        public List<BusinessAccount> BAccounts { get; set; }// = new List<BusinessAccount>();
        public List<CheckingAccount> CAccounts { get; set; }// = new List<CheckingAccount>();
        //public List<Loan> Loans { get; set; } = new List<Loan>();
        //public List<TermDeposit> TermDeposits { get; set; } = new List<TermDeposit>();
    }
}