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
        public List<OperationParameterDto> Parameters { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public AddOperationTypeCommand(string typeName, List<RuleDto> rules, List<OperationParameterDto> parameters, DateTimeOffset dateFrom, DateTimeOffset dueDate) => 
            (TypeName, Rules,Parameters, DateFrom, DueDate) = (typeName, rules, parameters, dateFrom, dueDate);

    }
}
