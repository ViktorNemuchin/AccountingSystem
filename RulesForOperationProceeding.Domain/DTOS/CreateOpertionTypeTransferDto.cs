using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class CreateOpertionTypeTransferDto
    {
        public string OperationTypeName { get; set; }
        public List<OperationParameterDto> Parametters { get; set; }
        public List<RuleDto> Rules { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
