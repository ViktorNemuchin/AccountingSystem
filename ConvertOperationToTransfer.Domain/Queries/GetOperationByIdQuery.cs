using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ConvertOperationToTransfer.Domain.Dtos;

namespace ConvertOperationToTransfer.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение операцию по Id
    /// </summary>
    public class GetOperationByIdQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }

        /// <summary>
        /// Конструктор класса запроса на получение операцию по Id
        /// </summary>
        /// <param name="operationId">Id операции</param>
        public GetOperationByIdQuery(Guid operationId) => (OperationId) = (operationId);
    }
}
