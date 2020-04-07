using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Domain.Models;

namespace RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext
{
    /// <summary>
    /// Класс контекст подключения к БД
    /// </summary>
    public class RulesForOperationProceedingDataDbContext: DbContext
    {
        /// <summary>
        /// Конструктор класса подключения к БД
        /// </summary>
        /// <param name="options">Конфигурация подключения к БД</param>
        public RulesForOperationProceedingDataDbContext(DbContextOptions<RulesForOperationProceedingDataDbContext> options)
            : base(options: options)
        {
        }
        /// <summary>
        ///  Подключение к таблице типов операции
        /// </summary>
        public DbSet<OperationTypeModel> OperationTypes { get; set; }
        
        /// <summary>
        /// Подключение к таблице правил 
        /// </summary>
        public DbSet<RulesModel> Rules { get; set; }

        /// <summary>
        /// Подключение к таблице параметров типов операций
        /// </summary>
        public DbSet<OperationParameterModel> OperationParameters { get; set; }

        /// <summary>
        /// Метод конфигурации мета данных для таблице
        /// </summary>
        /// <param name="modelBuilder"> Конструктор связей модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OperationTypeModel>()
                .HasKey(id => id.Id);

            modelBuilder
                .Entity<OperationTypeModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<RulesModel>()
                .HasKey(id => id.Id);

            modelBuilder
                .Entity<RulesModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<OperationParameterModel>()
                .HasKey(id => id.Id);

            modelBuilder
                .Entity<OperationParameterModel>()
                .Property(id => id.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
