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
        public List<TransferOperationParameterForUpdateDto> OperationParameters { get; private set; }
        public List<TransferRuleForUpdateDto> Rules { get; private set; }

        public UpdateOperationTypeCommand(Guid operationTypeId, string operationTypeName, List<TransferOperationParameterForUpdateDto> operationTypeParameters, List<TransferRuleForUpdateDto> rules) =>
            (OperationTypeId, OperationTypeName, OperationParameters, Rules) 
            = (operationTypeId, operationTypeName, operationTypeParameters, rules);
    }
}
