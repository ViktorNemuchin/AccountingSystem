using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ConvertOperationToTransfer.Domain.Dtos;

namespace ConvertOperationToTransfer.Domain.Queries
{
    public class GetOperationByIdQuery:BaseQuery<ResponseBaseDto>
    {
        public Guid OperationId { get; private set; }
        public GetOperationByIdQuery(Guid operationId) => (OperationId) = (operationId);
    }
}
