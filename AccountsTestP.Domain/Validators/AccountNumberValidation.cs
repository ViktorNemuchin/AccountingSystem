using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountsTestP.Domain.Validators
{
    /// <summary>
    /// Класс валидации указанного номера счета (20 - знаков с числовым значением)
    /// </summary>
    public class AccountNumberValidation
    {
        /// <summary>
        /// Метод валидации отрицательной суммы проводки (20 - знаков с числовым значением)
        /// </summary>
        /// <param name="accountNumber">Номер счета для проверки </param>
        /// <returns></returns>
        public static ValidationResult AccountNumberValidate(string accountNumber)
        {
            var regularExpression = new Regex(@"^\d{20}$");
            return !regularExpression.IsMatch(accountNumber)
                ? new ValidationResult("Enter right account")
                : ValidationResult.Success;
        }
    }
}
