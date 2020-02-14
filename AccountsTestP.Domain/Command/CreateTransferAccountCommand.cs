using AccountsTestP.Domain.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    public class CreateTransferAccountCommand : CommandBase<ResponseBaseDto>
    {
        public CreateTransferAccountCommand(int sourceAccountNumber, int destinationAccountNumber, decimal amount, DateTime actualDate, int sourceAccountType, int destinationAccountType,Guid documentId)
        {
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            ActualDate = actualDate;
            SourceAccountType = sourceAccountType;
            DestinationAccountType = DestinationAccountType;
            DocumentId = documentId;
        }
        [Required]
        [JsonPropertyName("source_account_id")]
        public int SourceAccountNumber { get; }
        [Required]
        [JsonPropertyName("destination_account_id")]
        public int DestinationAccountNumber { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        [Required]
        [JsonPropertyName("actual_date")]
        public DateTime ActualDate { get; }
        [Required]
        [JsonPropertyName("document_id")]
        public Guid DocumentId{get;}
        [Required]
        [JsonPropertyName("source_account_type")]
        public int SourceAccountType { get; }
        [Required]
        [JsonPropertyName("destination_account_type")]
        public int DestinationAccountType { get; }
    }
}
