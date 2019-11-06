using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Project1.Models.Accts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models
{
    public class Project1DbContext : IdentityDbContext
    {

        public Project1DbContext(DbContextOptions<Project1DbContext> context)
            : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=Project1Db;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<BusinessAccount> BusinessAccounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        //public DbSet<Loan> Loans{ get; set; }
        //public DbSet<TermDeposit> TermDeposits { get; set; }

        //public DbSet<Deposit> Deposits { get; set; }
        //public DbSet<DepositFromTermDeposit> FromTermDeposits  { get; set; }
        //public DbSet<TransferIn> InTransfers { get; set; }
        //public DbSet<TransferOut> OutTransfers { get; set; }
        //public DbSet<WithdrawToLoan> LoanWithdrawls { get; set; }
        //public DbSet<Withdrawl> Withdrawls { get; set; }
        //public DbSet<LoanPayment> LoanPayments { get; set; }

    }
}
