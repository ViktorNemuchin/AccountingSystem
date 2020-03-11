using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на полуение информации о счете по номеру счета
    /// </summary>
    public class GetAccountQuery : QueryBase<AccountDto>
    {
        /// <summary>
        /// Конструктор запроса на получение информации о счета по номеру счета 
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        public GetAccountQuery(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber { get; set; }
    }
}
