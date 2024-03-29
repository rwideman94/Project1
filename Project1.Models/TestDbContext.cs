﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Project1.Models.Accts;
using Project1.Models.Loans;
using Project1.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Models
{
    public class TestDbContext : IdentityDbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> context)
            : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=TestResetDB;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<TermDeposit> TermDeposits { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<OverdraftPaymentRecord> OverdraftPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("AccountType")
                .HasValue<BusinessAccount>("Business")
                .HasValue<CheckingAccount>("Checking");
        }

    }
}
