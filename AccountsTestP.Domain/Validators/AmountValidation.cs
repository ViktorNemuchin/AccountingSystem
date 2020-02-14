﻿using System.ComponentModel.DataAnnotations;

namespace AccountsTestP.Domain.Validators
{
    public class AmountValidation
    {
        public static ValidationResult AmountValidate(double amount)
        {
            return amount < 0
                ? new ValidationResult("Provide a positive amount")
                : ValidationResult.Success;
        }
    }
}
