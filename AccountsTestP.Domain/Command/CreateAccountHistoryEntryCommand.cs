using AccountsTestP.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    /// <summary>
    /// Класс команды на создания записи о проводке 
    /// </summary>
    public class CreateAccountHistoryEntryCommand : CommandBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструтор команды на создания записи о проводке
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="amount">Сумма</param>
        /// <param name="isTopUp">Флаг пополнения/спсиания со счета </param>
        /// <param name="dueDate">Дата влияния на проводку</param>
        /// <param name="accountType">Тип счета</param>
        /// <param name="operationId">Id операции</param>
        /// <param name="description">Описание</param>
        public CreateAccountHistoryEntryCommand(string accountNumber, 
                                               decimal amount, 
                                               bool isTopUp, 
                                               DateTimeOffset dueDate, 
                                               int accountType, 
                                               Guid operationId, 
                                               string description)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            IsTopUp = isTopUp;
            DueDate = dueDate;
            AccountType = accountType;
            OperationId = operationId;
            Description = description;
        }
        /// <summary>
        /// Номер счета
        /// </summary>
        [Required]
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; }
        /// <summary>
        /// Сумма проводки
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        /// <summary>
        /// Флаг списания/поплнения  
        /// </summary>
        [JsonIgnore]
        public bool IsTopUp { get; }
        /// <summary>
        /// Тип счета
        /// </summary>
        [JsonPropertyName("account_type")]
        public int AccountType { get; }
        /// <summary>
        /// Id операциии 
        /// </summary>
        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; }
        /// <summary>
        /// Дата влияния на счет
        /// </summary>
        [JsonPropertyName("due_date")]
        public DateTimeOffset DueDate { get; private set; }
        /// <summary>
        /// Описание
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; private set; }
    }
}
