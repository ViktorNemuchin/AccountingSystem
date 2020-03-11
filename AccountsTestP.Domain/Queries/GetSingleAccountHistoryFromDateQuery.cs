using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента  
    /// </summary>
    public class GetSingleAccountHistoryFromDateQuery:QueryBase<List<AccountHistoryDto>>
    {
        /// <summary>
        /// Конструтор запроса на получение информации о провоодках по указанному счету с указанной даты до текущего момента  
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <param name="dateTimeFrom">Дата</param>
        public GetSingleAccountHistoryFromDateQuery(Guid accountId, DateTimeOffset dateTimeFrom)
        {
            AccountId = accountId;
            DateTimeFrom = dateTimeFrom;
        }
        /// <summary>
        /// Id счета
        /// </summary>
        public Guid AccountId { get; private set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTimeOffset DateTimeFrom { get; private set; }
    }
}
