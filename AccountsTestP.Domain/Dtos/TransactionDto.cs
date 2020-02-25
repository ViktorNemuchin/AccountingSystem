using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class TransactionDto
    {
        [JsonPropertyName("source_account_id")]
        public Guid SourceAccountId { get; set; }

        [JsonPropertyName("destination_account_id")]
        public Guid DestinationAccountId { get; set; }

    }
}
