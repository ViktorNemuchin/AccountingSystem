using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Data.AccountDbContext
{
    public class AccountTestPDbContext: DbContext
    {
        private readonly AccountsGenerated _accounts;
        public AccountTestPDbContext(DbContextOptions<AccountTestPDbContext> options)
            : base(options: options)
        {
            _accounts = new AccountsGenerated();
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<AccountHistoryModel> AccountHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var accounts = _accounts.SeedAccounts();
            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(ca => ca.ChangedAt)
                .ValueGeneratedOnAdd();
            
            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<AccountModel>()
                .HasData(accounts);
        }
    }
}
