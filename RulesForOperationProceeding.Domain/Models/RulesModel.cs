using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    public class RulesModel : BaseModel
    {
        public string SourceAccount { get; private set; }
        public string DestinationAccount { get; private set; }
        public string Formula { get; private set; }
        public string Description { get; private set; }
        public Guid OperationTypeId { get; private set; }
        public int RuleOrderNumber { get; private set; }
        public DateTimeOffset DateFrom { get; private set; }

        public RulesModel(Guid id, string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description,DateTimeOffset dateFrom, Guid operationTypeId) =>
            (Id, SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description,DateFrom, OperationTypeId) = 
            (id, sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
        public RulesModel(string sourceAccount, string destinationAccount,int ruleOrderNumber, string formula, string description, DateTimeOffset dateFrom, Guid operationTypeId) =>
            (SourceAccount, DestinationAccount,RuleOrderNumber, Formula, Description, DateFrom, OperationTypeId) =
            (sourceAccount, destinationAccount,ruleOrderNumber, formula, description, dateFrom, operationTypeId);
    }
}
