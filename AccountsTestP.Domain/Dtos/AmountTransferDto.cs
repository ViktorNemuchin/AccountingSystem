using AccountsTestP.Domain.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AmountTransferDto
    {
        /// <summary>
        /// Номер счета с которго переводят денежные средства. Указываются только числа. Размер строки 20 символов
        /// </summary>
        [JsonPropertyName("source_account_number")]
        [CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string SourceAccountNumber { get; set; }
        /// <summary>
        /// Номер счета на который переводят денежные средства. Указываются только числа. Размер строки 20 символов
        /// </summary>
        [JsonPropertyName("destination_account_number")]
        [CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string DestinationAccountNumber { get; set; }
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
        [JsonPropertyName("actual_date")]
        public DateTimeOffset ActualDateTime { get; set; }
        /// <summary>
        /// Id операции
        /// </summary>
        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; set; }
        /// <summary>
        /// Тип счета донора
        /// </summary>
        [JsonPropertyName("source_account_type")]
        public int SourceAccountType { get; set; }
        /// <summary>
        /// Тип счета рецепиента
        /// </summary>
        [JsonPropertyName("destination_account_type")]
        public int DestinationAccountType { get; set; }
        /// <summary>
        /// Комментарии по счету
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
