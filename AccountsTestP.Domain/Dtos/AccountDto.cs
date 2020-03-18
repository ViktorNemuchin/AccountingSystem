using System;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO счета
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Id счета
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Текущий баланс
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        /// <summary>
        /// Тип счета
        /// </summary>
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }
        /// <summary>
        /// Флаг активного типа счета
        /// </summary>
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
