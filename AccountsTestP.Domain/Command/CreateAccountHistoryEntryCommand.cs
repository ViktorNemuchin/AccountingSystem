using AccountsTestP.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    public class CreateAccountHistoryEntryCommand : CommandBase<ResponseBaseDto>
    {
        public CreateAccountHistoryEntryCommand()
        {
        }
        public CreateAccountHistoryEntryCommand(string accountNumber, decimal amount, bool isTopUp, DateTimeOffset actualDate, int accountType, Guid operationId, string description)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            IsTopUp = isTopUp;
            ActualDate = actualDate;
            AccountType = accountType;
            OperationId = operationId;
            Description = description;
        }
        [Required]
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        [JsonIgnore]
        public bool IsTopUp { get; }
        [JsonPropertyName("account_type")]
        public int AccountType { get; }
        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; }
        [JsonPropertyName("actual_date")]
        public DateTimeOffset ActualDate { get; private set; }
        public string Description { get; private set; }
    }
}
