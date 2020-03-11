using System;
using System.Text.Json.Serialization;


namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO счета передающееся стороонним системам после проводки
    /// </summary>
    public class AccountTransferDto
    {
        /// <summary>
        /// ID счета
        /// </summary>
        [JsonPropertyName("account_id")]
        public Guid AccountId { get; set; }
        /// <summary>
        /// Текущий баланс счета
        /// </summary>
        [JsonPropertyName("current_balance")]
        public decimal CurrentBalance { get; set; }
        


    }
}
