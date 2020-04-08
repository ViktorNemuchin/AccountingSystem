using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение списка правил по Id типа операции для запроса полученя типа операции
    /// </summary>
    public class GetRulesForOperationTypeQueryByOperationId:BaseQuery<List<RuleDto>>
    {
        /// <summary>
        /// Конструктор класса запроса на получение списка правил по Id типа операции для запроса полученя типа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public GetRulesForOperationTypeQueryByOperationId(Guid operationTypeId) 
        {
            OperationTypeId = operationTypeId;
        }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set;}
    }
}
