using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetParametersForOperationByOperationIdQuery : BaseQuery<ResponseBaseDto>
    {
        public Guid OperationTypeId { get; set; }
        public GetParametersForOperationByOperationIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
