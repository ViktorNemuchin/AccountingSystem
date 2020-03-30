using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class CreateOperationTypeTransferDto
    {
        public string OperationTypeName { get; set; }
        public List<OperationParameterTransferDto> Parametters { get; set; }
        public List<TransferRuleDto> Rules { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
