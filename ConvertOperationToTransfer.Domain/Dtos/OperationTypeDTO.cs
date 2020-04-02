using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Dtos
{
    public class OperationTypeDto
    {
        public string OperationTypeName { get; set; }
        public List<OperationParameterDto> OperationParameters { get; set; }
        public List<RuleDto> Rules{get;set;}
    }
}
