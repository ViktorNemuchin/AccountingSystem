using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class TransactionDto
    {
        [JsonPropertyName("sorce_balnce")]
        public decimal SourceBalance { get; set; }

        [JsonPropertyName("destination_balance")]
        public decimal DestanationBalance { get; set; }
    }
}
