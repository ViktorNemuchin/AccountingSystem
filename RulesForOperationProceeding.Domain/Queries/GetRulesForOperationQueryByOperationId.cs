using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetRulesForOperationTypeQueryByOperationId:BaseQuery<List<RuleDto>>
    {
        public GetRulesForOperationTypeQueryByOperationId(Guid operationTypeId) 
        {
            OperationTypeId = operationTypeId;
        }
        public Guid OperationTypeId { get; private set;}
    }
}
