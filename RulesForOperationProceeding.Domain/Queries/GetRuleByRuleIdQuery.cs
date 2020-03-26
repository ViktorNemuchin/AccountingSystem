using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetRuleByRuleIdQuery: BaseQuery<ResponseBaseDto>
    {
        public GetRuleByRuleIdQuery(Guid ruleId) 
        {
            RuleId = ruleId;
        }
        public Guid RuleId { get; private set; }
    }
}
