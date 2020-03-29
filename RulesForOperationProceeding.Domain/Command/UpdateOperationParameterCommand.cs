using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class UpdateOperationParameterCommand: BaseCommand<ResponseBaseDto>
    {
        public Guid OperationParameterId { get; private set; }
        public string OperationParameterName { get; private set; }
        public string OperationParameterValue { get; private set; }
        public Guid OperationTypeId { get; private set; }
        public UpdateOperationParameterCommand(Guid operationParameterId, string operationParameterName, string operationParameterValue, Guid operationTypeId) => 
            (OperationParameterId, OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterId, operationParameterName, operationParameterValue, operationTypeId); 
    }
}
