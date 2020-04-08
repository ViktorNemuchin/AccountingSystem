using System;
using System.Collections.Generic;
using System.Text;
using ConvertOperationToTransfer.Domain.Dtos;
using MediatR;

namespace ConvertOperationToTransfer.Domain.Queries
{
    /// <summary>
    /// Класс запроса полученгие сформированных проводок по Id операции
    /// </summary>
    public class GetFormedTransferByOperationIdQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }

        /// <summary>
        /// Конструктор класса запроса полученгие сформированных проводок по Id операции
        /// </summary>
        /// <param name="operationId">Id операции</param>
        public GetFormedTransferByOperationIdQuery(Guid operationId) => (OperationId) = (operationId);
    }
}
