using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class AppUser : IdentityUser
    {

        public new int Id { get; set; }

        [Required]
        //[PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        //[PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[PersonalData]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        //[PersonalData]
        public string City { get; set; }

        [StringLength(maximumLength: 2)]
        //[PersonalData]
        public string State { get; set; }

        //public List<BusinessAccount> BAccounts { get; set; } = new List<BusinessAccount>();
        //public List<CheckingAccount> CAccounts { get; set; } = new List<CheckingAccount>();
        //public List<Loan> Loans { get; set; } = new List<Loan>();
        //public List<TermDeposit> TermDeposits { get; set; } = new List<TermDeposit>();
    }
}