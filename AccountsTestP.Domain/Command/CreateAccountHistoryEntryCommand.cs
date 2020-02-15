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
        public CreateAccountHistoryEntryCommand(string accountNumber, decimal amount, bool isTopUp, DateTime actualDate, int accountType, Guid operationId, int purpose)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            IsTopUp = isTopUp;
            ActualDate = actualDate;
            AccountType = accountType;
            OperationId = operationId;
            Purpose = purpose;
        }
        [Required]
        [JsonPropertyName("account_nu,ber")]
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
        public DateTime ActualDate { get; private set; }
        public int Purpose { get; private set; }
    }
}
