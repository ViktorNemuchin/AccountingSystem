using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса параметров типа операции для запроса получения тип операции
    /// </summary>
    public class GetParametersForOperationTypeQueryByOperationTypeIdQuery:BaseQuery<List<OperationParameterDto>>
    {
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }

        /// <summary>
        /// Конструктор класса запроса параметров типа операции для запроса получения тип операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public GetParametersForOperationTypeQueryByOperationTypeIdQuery(Guid operationTypeId) => (OperationTypeId) = (operationTypeId);
    }
}
