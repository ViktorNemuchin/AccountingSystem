using AccountsTestP.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// DTO проводки для десериализации JSON входящей в метод контроллера на пополнение или списания со счета 
    /// </summary>
    public class AmountOneDto
    {
        /// <summary>
        /// Номер счета. Указываются только числа. 
        /// </summary>
        //[CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// Сумма операции. Не должна быть меньше 0
        /// </summary>
        [JsonPropertyName("amount")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please provide right data type")]
        [CustomValidationAttribute(typeof(AmountValidation), nameof(AmountValidation.AmountValidate))]
        
        public double CurrentAmount { get; set; }
        /// <summary>
        /// Дата и время влияния на изменения в проводке
        /// </summary>
        [JsonPropertyName("due_date")]
        [Required]
        public DateTimeOffset DueDate { get; set; }
        /// <summary>
        /// Id операции
        /// </summary>
        [JsonPropertyName("operatoin_id")]
        [Required]
        public Guid OperationId { get; set; }
        /// <summary>
        /// Тип счета
        /// </summary>
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }
        /// <summary>
        /// Комментарии по счету
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
