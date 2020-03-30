using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Domain.Models;

namespace RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext
{
    public class RulesForOperationProceedingDataDbContext: DbContext
    {
        public RulesForOperationProceedingDataDbContext(DbContextOptions<RulesForOperationProceedingDataDbContext> options)
            : base(options: options)
        {
        }

        public DbSet<OperationTypeModel> OperationTypes { get; set; }
        public DbSet<RulesModel> Rules { get; set; }
        public DbSet<OperationParameterModel> OperationParameters { get; set; }

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
