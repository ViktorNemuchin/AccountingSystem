using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO проводки для отчетов 
    /// </summary>
    public class AccountHistoryDto
    {
        /// <summary>
        /// ID проводки
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Id счета с которого списывают сумму
        /// </summary>
        [JsonPropertyName("source_account_id")]
        public Guid SourceAccountId { get; set; }
        /// <summary>
        /// Id счета на который зачисляется сумма
        /// </summary>
        [JsonPropertyName("destination_account_id")]
        public Guid DestinationAccounId { get; set; }
        /// <summary>
        /// Id операциии
        /// </summary>
        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; set; }
        /// <summary>
        /// Баланс счета с которого списывают сумму после проведения проводки 
        /// </summary>
        [JsonPropertyName("source_balance")]
        public decimal SourceBalance { get; set; }
        /// <summary>
        /// Баланс счета на который списывают сумму после проведения проводки
        /// </summary>
        [JsonPropertyName("destination_balance")]
        public decimal DestinationBalance { get; set; }
        /// <summary>
        /// Сумма проводки
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Дата регистрации в системе
        /// </summary>
        [JsonPropertyName("changed_at")]
        public DateTimeOffset ChangedAt { get; set; }
        /// <summary>
        /// Дата влияния на изменение
        /// </summary>
        [JsonPropertyName("due_date")]
        public DateTimeOffset DueDateTime { get; set; }
       /// <summary>
       /// Описание проводки
       /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
