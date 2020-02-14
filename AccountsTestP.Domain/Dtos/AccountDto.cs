using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AccountDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("account_number")]
        public int AccountNumber { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonPropertyName("document_id")]
        public Guid DocumentId { get; set; }
        
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }
    }
}
