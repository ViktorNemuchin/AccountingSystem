using System;
using System.Text.Json.Serialization;


namespace AccountsTestP.Domain.Dtos
{
    public class AccountTransferDto
    {

        [JsonPropertyName("account_id")]
        public Guid AccountId { get; set; }
        [JsonPropertyName("current_balance")]
        public decimal CurrentBalance { get; set; }
        


    }
}
