using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ConvertOperationToTransfer.Domain.Models;

namespace ConvertOperationToTransfer.Data.ConvertOperationsDbContext
{
    public class ConvertOperationToTransferDbContext:DbContext
    {
        public ConvertOperationToTransferDbContext(DbContextOptions<ConvertOperationToTransferDbContext> options) 
            :base(options:options)    
        { }

        public DbSet<OperationModel> Operations { get; set; }
        public DbSet<OperationParameterModel> OperationParameters { get; set; }
        public DbSet<OperationTransferModel> Transfers { get; set; }
    }
}
