using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    public class AddRuleToOperationTypeIdCommand : BaseCommand<ResponseBaseDto>
    {
        public string SourceAccount { get; private set; }
        public string DestinationAccount { get; private set; }
        public string Formula { get; private set; }
        public string Description { get; private set; }
        public Guid OperationId { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public AddRuleToOperationTypeIdCommand(string sourceAccount, string destinationAccount, string formula, string description,DateTimeOffset dateFrom, Guid operationTypeId) =>
            (SourceAccount, DestinationAccount, Formula, Description,DateFrom, OperationId) = (sourceAccount, destinationAccount, formula, description, dateFrom, operationTypeId);
    }
}
