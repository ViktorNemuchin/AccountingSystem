using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    public class UpdateOperationTypeCommand:BaseCommand<ResponseBaseDto>
    {
        public Guid OperationTypeId { get; private set; }
        public string OperationTypeName { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public List<OperationParameterDto> OperationParameters { get; private set; }
        public List<RuleDto> Rules { get; private set; }

        public UpdateOperationTypeCommand(Guid operationTypeId, string operationTypeName, DateTimeOffset dateFrom, DateTimeOffset dueDate, List<OperationParameterDto> operationTypeParameters, List<RuleDto> rules) =>
            (OperationTypeId, OperationTypeName, DateFrom, DueDate, OperationParameters, Rules) 
            = (operationTypeId, operationTypeName,dateFrom,dueDate, operationTypeParameters, rules);
    }
}
