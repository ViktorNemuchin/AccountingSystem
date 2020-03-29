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

    }
}
