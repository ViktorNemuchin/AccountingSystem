using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsTestP.Data.AccountDbContext
{
    public class AccountTestPDbContext : DbContext
    {
        public AccountTestPDbContext(DbContextOptions<AccountTestPDbContext> options)
            : base(options: options)
        {
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<AccountHistoryModel> AccountHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(ca => ca.ChangedAt)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
