using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ConvertOperationToTransfer.Domain.Models;

namespace ConvertOperationToTransfer.Data.ConvertOperationsDbContext
{
    /// <summary>
    /// Класс контекст подключения к БД
    /// </summary>
    public class ConvertOperationToTransferDbContext:DbContext
    {
        /// <summary>
        /// Конструкция класса подключения к БД
        /// </summary>
        /// <param name="options">Конфигурация подключения к БД</param>
        public ConvertOperationToTransferDbContext(DbContextOptions<ConvertOperationToTransferDbContext> options) 
            :base(options:options)    
        { }

        /// <summary>
        /// Подключение к таблице журнала операций
        /// </summary>
        public DbSet<OperationModel> Operations { get; set; }

        /// <summary>
        /// Подключение к таблице журнала проводок
        /// </summary>
        public DbSet<OperationParameterModel> OperationParameters { get; set; }

        /// <summary>
        /// Подключение к таблице сгенерированных проводок
        /// </summary>
        public DbSet<OperationTransferModel> Transfers { get; set; }
    }
}
