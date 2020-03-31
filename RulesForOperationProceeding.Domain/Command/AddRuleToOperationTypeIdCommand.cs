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
        public int RuleOrderNumber { get; private set; }
        public string Formula { get; private set; }
        public string Description { get; private set; }
        public Guid OperationId { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }
        public AddRuleToOperationTypeIdCommand(string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description,DateTimeOffset dateFrom, Guid operationTypeId) =>
            (SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description,DateFrom, OperationId) = (sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
    }
}
