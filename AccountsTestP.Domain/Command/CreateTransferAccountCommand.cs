using AccountsTestP.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    /// <summary>
    /// Класс команды на создание записи в журнале провододки при проведении транзакции между двумя счетами
    /// </summary>
    public class CreateTransferAccountCommand : CommandBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор команды на создание записи в журнале провододки при проведении транзакции между двумя счетами
        /// </summary>
        /// <param name="sourceAccountNumber"> Номер счета списания</param>
        /// <param name="destinationAccountNumber">Номер счета зачисления</param>
        /// <param name="amount">Сумма проводки </param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="sourceAccountType">Тип счета списания</param>
        /// <param name="destinationAccountType">Тип счета зачисления</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="description">Описание</param>
        public CreateTransferAccountCommand(string sourceAccountNumber, 
                                           string destinationAccountNumber, 
                                           decimal amount, 
                                           DateTimeOffset dueDate, 
                                           int sourceAccountType, 
                                           int destinationAccountType,
                                           Guid operationId, 
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
        /// Номер счета списания
        /// </summary>
        [Required]
        [JsonPropertyName("source_account_number")]
        public string SourceAccountNumber { get; }
        /// <summary>
        /// Номер счета начисления
        /// </summary>
        [Required]
        [JsonPropertyName("destination_account_number")]
        public string DestinationAccountNumber { get; }
        /// <summary>
        /// Сумма счета
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        /// <summary>
        /// Дата влияния проводки на счет
        /// </summary>
        [Required]
        [JsonPropertyName("due_date")]
        public DateTimeOffset DueDate { get; }
        /// <summary>
        /// Id операции
        /// </summary>
        [Required]
        [JsonPropertyName("operation_id")]
        public Guid OperationId{get;}
        /// <summary>
        /// Тип счета списания
        /// </summary>
        [Required]
        [JsonPropertyName("source_account_type")]
        public int SourceAccountType { get; }
        /// <summary>
        /// Тип счета начисления
        /// </summary>
        [Required]
        [JsonPropertyName("destination_account_type")]
        public int DestinationAccountType { get; }
        /// <summary>
        /// Описание
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; } 
    }
}
