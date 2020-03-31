using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class TransferRuleForRuleControllerDto:TransferRuleDto
    {
       public DateTimeOffset DateFrom { get; set; }
    }
}
