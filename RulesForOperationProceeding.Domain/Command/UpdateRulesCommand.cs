using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class UpdateRulesCommand: BaseCommand<ResponseBaseDto>
    {
        public List<RuleDto> RulesForUpdate { get; private set; }
        public UpdateRulesCommand(List<RuleDto> rulesForUpdate) => (RulesForUpdate) = (rulesForUpdate);
    }
}
