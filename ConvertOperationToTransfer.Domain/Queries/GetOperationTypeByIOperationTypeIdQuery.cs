using System;
using System.Collections.Generic;
using System.Text;
using ConvertOperationToTransfer.Domain.Dtos;
using MediatR;

namespace ConvertOperationToTransfer.Domain.Queries
{
    class GetOperationTypeByIOperationTypeIdQuery:BaseQuery<ResponseBaseDto>
    {
        public Guid OperationTypeId { get; private set; }
        public GetOperationTypeByIOperationTypeIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
