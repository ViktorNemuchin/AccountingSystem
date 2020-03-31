using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class OperationTypeTransferDto
    {
        public string OperationTypeName { get; set; }
        public List<TransferOperationParameterDto> OperationParameters { get; set; }
        public List<TransferRuleDto> Rules { get; set; }
        public DateTimeOffset DateFrom { get; set; }
    }
}
