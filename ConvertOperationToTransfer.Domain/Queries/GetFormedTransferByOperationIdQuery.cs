using System;
using System.Collections.Generic;
using System.Text;
using ConvertOperationToTransfer.Domain.Dtos;
using MediatR;

namespace ConvertOperationToTransfer.Domain.Queries
{
    public class GetFormedTransferByOperationIdQuery:BaseQuery<ResponseBaseDto>
    {
        public Guid OperationId { get; private set; }
        public GetFormedTransferByOperationIdQuery(Guid operationId) => (OperationId) = (operationId);
    }
}
