using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс описания запроса баланса счета на дату 
    /// </summary>
    public class GetAccountBalanceByDateQuery : QueryBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор баланса счета на дату
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <param name="dateBy">Дата </param>
        public GetAccountBalanceByDateQuery(Guid accountId, DateTimeOffset dateBy ) 
        {
            AccountId = accountId;
            DateBy = dateBy;
        }
        /// <summary>
        /// Id счета
        /// </summary>
        public Guid AccountId { get; private set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTimeOffset DateBy { get; private set; }


    }
}
