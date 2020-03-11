using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получкения записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки 
    /// </summary>
    public class GetAccountHistoryFromDateQuery:QueryBase<List<AccountHistoryDto>>
    {
        /// <summary>
        /// Конструктор запроса на получение записи всех проводок с указанной даты для счета списания и зачисления в рамках корректирующей проводки
        /// </summary>
        /// <param name="sourceAccountId">Id счета списания</param>
        /// <param name="destinationAccountId">Id счета зачисления</param>
        /// <param name="dateTimeFrom">Исходная дата</param>
        public GetAccountHistoryFromDateQuery(Guid sourceAccountId,Guid destinationAccountId, DateTimeOffset dateTimeFrom)
        {
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            DateTimeFrom = dateTimeFrom;
        }
        /// <summary>
        /// Id счета списания
        /// </summary>
        public Guid SourceAccountId { get; private set; }
        /// <summary>
        /// Id счета зачисления
        /// </summary>
        public Guid DestinationAccountId { get; private set; }
        /// <summary>
        /// Исходная дата
        /// </summary>
        public DateTimeOffset DateTimeFrom { get; private set; }
    }
}
