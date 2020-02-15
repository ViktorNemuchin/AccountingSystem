using AccountsTestP.Domain.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AmountTransferDto
    {
        [JsonPropertyName("source_account_number")]
        [CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string SourceAccountNumber { get; set; }

        [JsonPropertyName("destination_account_number")]
        [CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string DestinationAccountNumber { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please provide right data type")]
        [CustomValidationAttribute(typeof(AmountValidation), nameof(AmountValidation.AmountValidate))]
        public double CurrentAmount { get; set; }
        [JsonPropertyName("actual_date")]
        public DateTime ActualDateTime { get; set; }

        [JsonPropertyName("operation_id")]
        public Guid OperationId { get; set; }
        [JsonPropertyName("source_account_type")]
        public int SourceAccountType { get; set; }

        [JsonPropertyName("destination_account_type")]
        public int DestinationAccountType { get; set; }
        [JsonPropertyName("Purpose")]
        public int Purpose { get; set; }
    }
}
