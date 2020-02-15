using AccountsTestP.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class AmountOneDto
    {
        [CustomValidationAttribute(typeof(AccountNumberValidation), nameof(AccountNumberValidation.AccountNumberValidate))]
        public string AccountNumber { get; set; }
        [JsonPropertyName("amount")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please provide right data type")]
        [CustomValidationAttribute(typeof(AmountValidation), nameof(AmountValidation.AmountValidate))]
        
        public double CurrentAmount { get; set; }
        
        [JsonPropertyName("actual_date_time")]
        [Required]
        public DateTime ActualDateTime { get; set; }

        [JsonPropertyName("operatoin_id")]
        [Required]
        public Guid OperationId { get; set; }
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }
        [JsonPropertyName("purpose")]
        public int Puprpose { get; set; }
    }
}
