using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получения списка всех проводок для указанного счета
    /// </summary>
    public class GetAccountHistoryQuery : QueryBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор запроса на получение списка всех проводок для указанного счета
        /// </summary>
        /// <param name="accountId">Id счета</param>
        public GetAccountHistoryQuery(Guid accountId)
        {
            AccountId = accountId;
        }
        /// <summary>
        /// Id счета
        /// </summary>
        public Guid AccountId { get; set; }
    }
}
