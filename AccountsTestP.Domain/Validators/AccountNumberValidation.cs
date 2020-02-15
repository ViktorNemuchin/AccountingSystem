using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountsTestP.Domain.Validators
{
    public class AccountNumberValidation
    {
        public static ValidationResult AccountNumberValidate(string accountNumber)
        {
            var regularExpression = new Regex(@"^\d{20}$");
            return !regularExpression.IsMatch(accountNumber)
                ? new ValidationResult("Enter right account")
                : ValidationResult.Success;
        }
    }
}
