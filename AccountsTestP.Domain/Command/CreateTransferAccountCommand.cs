using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    public class CreateTransferAccountCommand : CommandBase<ResponseBaseDto>
    {
        public CreateTransferAccountCommand(int sourceAccountId, int destinationAccountId, decimal amount) 
        {
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
        }
        [Required]
        [JsonPropertyName("source_account_id")]
        public int SourceAccountId { get; }
        [Required]
        [JsonPropertyName("destination_account_id")]
        public int DestinationAccountId { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
    }
}
