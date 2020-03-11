using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO результата при успешно выполненой комманде о проведении проводки
    /// </summary>
    public class TransactionDto
    {
        /// <summary>
        /// Id счета с которго списывается проводка
        /// </summary>
        [JsonPropertyName("source_account_id")]
        public Guid SourceAccountId { get; set; }
        /// <summary>
        /// Id счета зачисления
        /// </summary>
        [JsonPropertyName("destination_account_id")]
        public Guid DestinationAccountId { get; set; }

    }
}
