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

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("changed_at")]
        public DateTime ChangedAt { get; set; }

        [JsonPropertyName("actual_date_time")]
        public DateTime ActualDateTime { get; set; }
        [JsonPropertyName("purpose")]
        public int Purpose { get; set; }
    }

}
