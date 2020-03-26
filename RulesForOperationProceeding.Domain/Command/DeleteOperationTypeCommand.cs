using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    public class DeleteOperationTypeCommand:BaseCommand<ResponseBaseDto>
    {
        public Guid OperationTypeId { get; private set; }
        public DeleteOperationTypeCommand(Guid operationTypeId) => (OperationTypeId)=(operationTypeId);
    }
}
