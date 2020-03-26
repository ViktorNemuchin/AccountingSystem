using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetOperationTypeByIdQuery:BaseQuery<ResponseBaseDto>
    {
        public GetOperationTypeByIdQuery(Guid operationId) 
        {
            OperationId = operationId;
        }
        public Guid OperationId { get; private set; }
    }
}
