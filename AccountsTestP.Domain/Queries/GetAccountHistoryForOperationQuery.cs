using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение всех проводок в рамках указанной операции
    /// </summary>
    public class GetAccountHistoryForOperationQuery: QueryBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор запроса на получение всей истории по счету
        /// </summary>
        /// <param name="operationId">Id операции</param>
        public GetAccountHistoryForOperationQuery(Guid operationId) 
        {
            OperationId = operationId;
        }
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; }

    }
}
