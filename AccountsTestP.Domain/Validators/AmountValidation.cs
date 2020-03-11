using System.ComponentModel.DataAnnotations;

namespace AccountsTestP.Domain.Validators
{
    /// <summary>
    /// Класс валидации суммы проводок на отрицательные значения
    /// </summary>
    public class AmountValidation
    {
        /// <summary>
        /// Метол валидации суммы проводок на отрицательные значения
        /// </summary>
        /// <param name="amount">Сумма проводки</param>
        /// <returns></returns>
        public static ValidationResult AmountValidate(double amount)
        {
            return amount < 0
                ? new ValidationResult("Provide a positive amount")
                : ValidationResult.Success;
        }
    }
}
