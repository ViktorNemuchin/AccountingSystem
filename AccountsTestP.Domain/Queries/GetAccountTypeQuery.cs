using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение типа счета
    /// </summary>
    public class GetAccountTypeQuery:QueryBase<ResponseBaseDto>
    {
        /// <summary>
        /// Номер типа счета
        /// </summary>
        public int AccountTypeNumber { get; private set; }

        /// <summary>
        /// Конструктор запроса на получение типа счета
        /// </summary>
        /// <param name="accountTypeNumber">Номер типа счета</param>
        public GetAccountTypeQuery(int accountTypeNumber) 
        {
            AccountTypeNumber = accountTypeNumber;
        }
    }
}
