using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class UpdateOperationTypeTransferDto
    {
        public string OperationTypeName { get; set; }
        public List<TransferOperationParameterForUpdateDto> OperationParameters { get; set; }
        public List<TransferRuleForUpdateDto> Rules { get; set; }
    }
}
