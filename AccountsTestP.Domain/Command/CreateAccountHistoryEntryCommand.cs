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
        public CreateAccountHistoryEntryCommand(int accountNumber, decimal amount, bool isTopUp, DateTime actualDate, int accountType, Guid documentId)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            IsTopUp = isTopUp;
            ActualDate = actualDate;
            AccountType = accountType;
            DocumentId = documentId;
        }
        [Required]
        [JsonPropertyName("account_nu,ber")]
        public int AccountNumber { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        [JsonIgnore]
        public bool IsTopUp { get; }
        public int AccountType { get; }
        public Guid DocumentId { get; } 
        public DateTime ActualDate { get; set; } 
    }
}
