using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AccountDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}
