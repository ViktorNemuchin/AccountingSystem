using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetParametersForOperationTypeQueryByOperationTypeIdQuery:BaseQuery<List<OperationParameterDto>>
    {
        public Guid OperationTypeId { get; set; }
        public GetParametersForOperationTypeQueryByOperationTypeIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
