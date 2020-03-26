using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class DeleteRuleCommand:BaseCommand<ResponseBaseDto>
    {
        public Guid RuleId { get; private set; }
        public DeleteRuleCommand(Guid ruleId) => (RuleId) = (ruleId);
    }
}
