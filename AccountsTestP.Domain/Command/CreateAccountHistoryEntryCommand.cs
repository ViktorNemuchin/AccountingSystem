using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Command
{
    public class CreateAccountHistoryEntryCommand: CommandBase<ResponseBaseDto>
    {
        public CreateAccountHistoryEntryCommand() 
        {
        }
        public CreateAccountHistoryEntryCommand(int accountId, decimal amount, bool isTopUp) 
        {
            AccountId = accountId;
            Amount = amount;
            IsTopUp = isTopUp;
        }
        [Required]
        [JsonPropertyName("account_id")]     
        public int AccountId { get; }
        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; }
        [JsonIgnore]
        public bool IsTopUp { get;} 
    }
}
