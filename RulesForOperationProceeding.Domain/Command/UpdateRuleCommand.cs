using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public class UpdateRuleCommand:BaseCommand<ResponseBaseDto>
    {
        public Guid RuleId { get; private set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public string Formula { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public Guid OperationTypeId { get; set; }
        public UpdateRuleCommand(Guid ruleId, string sourceAccount, string destinationAccount, string formula, string description, DateTimeOffset dateFrom, Guid operationTypeId) =>
            (RuleId, SourceAccount, DestinationAccount, Formula, Description, DateFrom, OperationTypeId) =
            (ruleId, sourceAccount, destinationAccount, formula, description, dateFrom, operationTypeId);
    }

}
