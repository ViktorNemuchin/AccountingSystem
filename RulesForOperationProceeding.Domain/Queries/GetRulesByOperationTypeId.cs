using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetRulesByOperationTypeId:BaseQuery<ResponseBaseDto>
    {
        public GetRulesByOperationTypeId(Guid operationTypeId)
        {
            OperationTypeId = operationTypeId;
        }
        public Guid OperationTypeId { get; private set; }
    }
}
