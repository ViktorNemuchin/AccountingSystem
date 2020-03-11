using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    /// <summary>
    /// Модель описания таблицы буфера будущих проводок 
    /// </summary>
    public class BufferForFutureEntriesDatesModel:BaseModel
    {
        /// <summary>
        /// Номер счета списания 
        /// </summary>
        public string SourceAccountNumber { get; private set; }
        /// <summary>
        /// Номер счета зачисления
        /// </summary>
        public string DestinationAccountNumber { get; private set; }
        /// <summary>
        /// Сумма проводки
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// дата влияния на счет
        /// </summary>
        public DateTimeOffset DueDate { get; private set; }
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }
        /// <summary>
        /// Тип счета списания
        /// </summary>
        public int SourceAccountType { get; private set; }
        /// <summary>
        /// Тип счета зачисления
        /// </summary>
        public int DestinationAccountType { get; private set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Конструктор модели описания таблицы буфера будущих проводок
        /// </summary>
        /// <param name="sourceAccountNumber">Номер счета списания</param>
        /// <param name="destinationAccountNumber">Номер счета зачисления</param>
        /// <param name="amount">Сумма проводки</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="sourceAccountType">Тип счета списания</param>
        /// <param name="destinationAccountType">Тип счета зачисления</param>
        /// <param name="description">Описание</param>
        public BufferForFutureEntriesDatesModel(string sourceAccountNumber, 
            string destinationAccountNumber, 
            decimal amount, 
            DateTimeOffset dueDate,
            Guid operationId,
            int sourceAccountType, 
            int destinationAccountType,  
            string description)
        {
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            DueDate = dueDate;
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            OperationId = operationId;
            Description = description;
        }
        /// <summary>
        /// Конструктор модели описания таблицы буфера будущих проводок
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="sourceAccountNumber">Номер счета спсиания</param>
        /// <param name="destinationAccountNumber">Номер счета зачисления</param>
        /// <param name="amount">Сумма</param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="operationId">Id операции </param>
        /// <param name="sourceAccountType">Тип счета списания</param>
        /// <param name="destinationAccountType">Тип счета зачисления</param>
        /// <param name="description">Описание</param>
        public BufferForFutureEntriesDatesModel(Guid id, string sourceAccountNumber,
           string destinationAccountNumber,
           decimal amount,
           DateTimeOffset dueDate,
           Guid operationId,
           int sourceAccountType,
           int destinationAccountType,
           string description)
        {
            Id = id;
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            DueDate = dueDate;
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            OperationId = operationId;
            Description = description;
        }


    }
}
