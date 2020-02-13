using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using AccountsTestP.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AccountsTestP.Domain.Dtos
{
    public class AmountTransferDto
    {
        [JsonPropertyName("amount")]
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Please provide right data type")]
        [CustomValidationAttribute(typeof(AmountValidation), nameof(AmountValidation.AmountValidate) )]
        public double CurrentAmount { get; set; }
    }
}
