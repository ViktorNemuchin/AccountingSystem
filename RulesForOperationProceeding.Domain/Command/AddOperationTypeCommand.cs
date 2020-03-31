using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class AddOperationTypeCommand: BaseCommand<ResponseBaseDto>
    {
        public string TypeName { get; private set; }
        public List<TransferRuleDto> Rules { get; private set; }
        public List<TransferOperationParameterDto> Parameters { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public AddOperationTypeCommand(string typeName, List<TransferRuleDto> rules, List<TransferOperationParameterDto> parameters, DateTimeOffset dateFrom) => 
            (TypeName, Rules,Parameters, DateFrom) = (typeName, rules, parameters, dateFrom);

    }
}
