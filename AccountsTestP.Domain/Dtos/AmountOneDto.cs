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
        [JsonPropertyName("amount")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please provide right data type")]
        [CustomValidationAttribute(typeof(AmountValidation), nameof(AmountValidation.AmountValidate))]
        public double CurrentAmount { get; set; }
        [JsonPropertyName("actual_date")]
        public DateTime ActualDateTime { get; set; }

        [JsonPropertyName("document_id")]
        public Guid DocumentId { get; set; }
        [JsonPropertyName("account_type")]
        public int AccountType { get; set; }


    }
}
