using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение типов операции по Id типа операции
    /// </summary>
    public class GetOperationTypeByIdQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор класса запроса на получение типов операции по Id типа операции
        /// </summary>
        /// <param name="operationId">Id типа операции</param>
        public GetOperationTypeByIdQuery(Guid operationId) 
        {
            OperationId = operationId;
        }
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationId { get; private set; }
    }
}
