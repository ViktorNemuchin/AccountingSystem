using AccountsTestP.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    public class CreateTransferAccountCommand : CommandBase<ResponseBaseDto>
    {
        public CreateTransferAccountCommand(string sourceAccountNumber, string destinationAccountNumber, decimal amount, DateTimeOffset actualDate, int sourceAccountType, int destinationAccountType,Guid operationId, string description)
        {
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            ActualDate = actualDate;
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            OperationId = operationId;
            Description = description;
        }
        [Required]
        [JsonPropertyName("source_account_id")]
        public string SourceAccountNumber { get; }
        [Required]
        [JsonPropertyName("destination_account_id")]
        public string DestinationAccountNumber { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        [Required]
        [JsonPropertyName("actual_date")]
        public DateTimeOffset ActualDate { get; }
        [Required]
        [JsonPropertyName("document_id")]
        public Guid OperationId{get;}
        [Required]
        [JsonPropertyName("source_account_type")]
        public int SourceAccountType { get; }
        [Required]
        [JsonPropertyName("destination_account_type")]
        public int DestinationAccountType { get; }
        public string Description { get; } 
    }
}
