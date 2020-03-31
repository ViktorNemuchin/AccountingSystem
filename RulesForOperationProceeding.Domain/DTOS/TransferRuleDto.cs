using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class TransferRuleDto
    {
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public int RuleOrderNumber { get; set; }
        public string Formula { get; set; }
        public string Description { get; set; }
    }
}
