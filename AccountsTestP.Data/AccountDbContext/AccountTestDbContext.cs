using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;

namespace AccountsTestP.Data.AccountDbContext
{/// <summary>
/// Класс для подключения и работы с бд системы регистрации проводок 
/// </summary>
    public class AccountTestPDbContext : DbContext
    {
        /// <summary>
        /// Конструктор класса для подключения и работы с бд системы регистрации проводок
        /// </summary>
        /// <param name="options">Опции для подключения и настройки контекста работы с бд</param>
        public AccountTestPDbContext(DbContextOptions<AccountTestPDbContext> options)
            : base(options: options)
        {
        }
        /// <summary>
        /// Таблица счетов
        /// </summary>
        public DbSet<AccountModel> Accounts { get; set; }
        /// <summary>
        /// Таблица журнала проводок 
        /// </summary>
        public DbSet<AccountHistoryModel> AccountHistory { get; set; }
        /// <summary>
        /// Таблица типа счетов
        /// </summary>
        public DbSet<AccountTypeModel> AccountTypes { get; set; }
        /// <summary>
        /// Таблица для хранения записей для регистрации  
        /// </summary>
        public DbSet<BufferForFutureEntriesDatesModel> Buffer { get; set; }
        /// <summary>
        /// Метод определения связей и свойств полей в таблице 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var helper = new AccountEntityGenerator();
            var accountTypes = helper.SetAccountTypes();
            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(ca => ca.CreationDate)
                .ValueGeneratedOnAdd();


            modelBuilder
                .Entity<AccountHistoryModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
               .Entity<AccountTypeModel>()
               .HasKey(id => id.Id);

            modelBuilder
                .Entity<AccountTypeModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<AccountTypeModel>()
                .HasData(accountTypes);
                
        }
    }
}
