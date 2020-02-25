using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountHistoryForOperationQuery: QueryBase<ResponseBaseDto>
    {
        public GetAccountHistoryForOperationQuery(Guid operationId) 
        {
            OperationId = operationId;
        }

        public Guid OperationId { get; }

    }
}
