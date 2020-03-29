using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    public class AddOperationParameterCommand:BaseCommand<ResponseBaseDto>
    {
        public string OperationParameterName { get; private set; }
        public string OperationParameterValue { get; private set; }
        public Guid OperationTypeId { get; private set; }

        public AddOperationParameterCommand(string operationParameterName, string operationParameterValue, Guid operationTypeId) => 
            (OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterName, operationParameterValue, operationTypeId);
    }
}
