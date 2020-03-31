using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class TransferRuleForUpdateDto: TransferRuleDto
    {
        public Guid RuleId { get; set; }
        public DateTimeOffset DateFrom { get; set; }
    }
}
