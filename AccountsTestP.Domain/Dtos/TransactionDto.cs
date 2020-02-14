using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class TransactionDto
    {
        [JsonPropertyName("source_account_id")]
        public Guid SourceAccountId { get; set; }

        [JsonPropertyName("source_account_balnce")]
        public decimal SourceBalance { get; set; }

        [JsonPropertyName("destination_account_id")]
        public Guid DestinationAccountId { get; set; }

        [JsonPropertyName("destination_account_balance")]
        public decimal DestanationBalance { get; set; }
    }
}
