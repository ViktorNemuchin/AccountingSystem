using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class OperationParameterDto
    {
        public Guid OperationParameterId { get; set; }
        public string OperationParameterName { get; set; }
        public string OperationParameter { get; set; }
        public Guid OperationId { get; set; }

    }
}
