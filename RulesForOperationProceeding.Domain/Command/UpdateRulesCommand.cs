using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class UpdateRulesCommand: BaseCommand<ResponseBaseDto>
    {
        public List<RulesForUpdateDto> RulesForUpdate { get; private set; }
        public UpdateRulesCommand(List<RulesForUpdateDto> rulesForUpdate) => (RulesForUpdate) = (rulesForUpdate);
    }
}
