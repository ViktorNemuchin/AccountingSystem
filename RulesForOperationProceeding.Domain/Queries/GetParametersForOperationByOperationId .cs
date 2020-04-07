using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса спсика параметров типа операции по Id типа операции 
    /// </summary>
    public class GetParametersForOperationByOperationIdQuery : BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }

        /// <summary>
        /// Конструктор класса запроса спсика параметров типа операции по Id типа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public GetParametersForOperationByOperationIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
