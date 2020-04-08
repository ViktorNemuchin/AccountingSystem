using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса на олучение списка правил по Id типа операции
    /// </summary>
    public class GetRulesByOperationTypeIdQuery:BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор класса запроса на олучение списка правил по Id типа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public GetRulesByOperationTypeIdQuery(Guid operationTypeId)
        {
            OperationTypeId = operationTypeId;
        }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }
    }
}
