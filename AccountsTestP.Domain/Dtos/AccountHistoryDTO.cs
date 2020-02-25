using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AccountHistoryDto
    {
        
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("source_account_id")]
        public Guid SourceAccountId { get; set; }

        [JsonPropertyName("destination_account_id")]
        public Guid DestinationAccounId { get; set; }
        
        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; set; }
        
        [JsonPropertyName("source_balance")]
        public decimal SourceBalance { get; set; }
        
        [JsonPropertyName("destination_balance")]
        public decimal DestinationBalance { get; set; }
        
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("changed_at")]
        public DateTimeOffset ChangedAt { get; set; }

        [JsonPropertyName("due_date_time")]
        public DateTimeOffset DueDateTime { get; set; }
       
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
