using System;
using System.Collections.Generic;
using System.Text;
using ConvertOperationToTransfer.Domain.Dtos;
using MediatR;

namespace ConvertOperationToTransfer.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение типоа операции
    /// </summary>
    class GetOperationTypeByIOperationTypeIdQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }

        /// <summary>
        /// Конструктор класса запроса на получение типоа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public GetOperationTypeByIOperationTypeIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
