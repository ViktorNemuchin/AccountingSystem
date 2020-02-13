using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AccountsTestP.Domain.Dtos
{
    public class AccountHistoryDto
    {
   
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("changed_at")]
        public DateTime ChangedAt { get; set; }
    }
    
}
