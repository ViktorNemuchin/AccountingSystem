using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class TransferOperationParameterForUpdateDto:TransferOperationParameterDto
    {
        public Guid OperationParameterId { get; set; }
    }
}
