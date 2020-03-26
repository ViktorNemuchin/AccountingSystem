using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class AddOperationTypeCommand: BaseCommand<ResponseBaseDto>
    {
        public string TypeName { get; private set; }
        public List<RuleDto> Rules { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public AddOperationTypeCommand(string typeName, List<RuleDto> rules, DateTimeOffset dateFrom) => (TypeName, Rules, DateFrom) = (typeName, rules, dateFrom);

    }
}
