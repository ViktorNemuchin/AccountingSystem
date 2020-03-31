using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetRulesByOperationTypeIdQuery:BaseQuery<ResponseBaseDto>
    {
        public GetRulesByOperationTypeIdQuery(Guid operationTypeId)
        {
            OperationTypeId = operationTypeId;
        }
        public Guid OperationTypeId { get; private set; }
    }
}
