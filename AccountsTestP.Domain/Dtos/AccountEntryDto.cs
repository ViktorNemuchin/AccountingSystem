using System;
using System.Text.Json.Serialization;


namespace AccountsTestP.Domain.Dtos
{
    public class AccountEntryDto
    {

        [JsonPropertyName("account_id")]
        public Guid AccountId { get; set; }
        [JsonPropertyName("current_balance")]
        public decimal CurrentBalance { get; set; }
        


    }
}
