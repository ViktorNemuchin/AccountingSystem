using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class DeleteOperationParameterCommand : BaseCommand<ResponseBaseDto>
    {
        public Guid OperationParameterId { get; private set; }
        public DeleteOperationParameterCommand(Guid operationParameterId) => (OperationParameterId) = (operationParameterId);
    }
}
