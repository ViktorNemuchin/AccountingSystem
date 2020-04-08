using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Класс запроса на получение правила по его идентификатору  
    /// </summary>
    public class GetRuleByRuleIdQuery: BaseQuery<ResponseBaseDto>
    {
        /// <summary>
        /// Конструктор класса запроса на получение правила по его идентификатору
        /// </summary>
        /// <param name="ruleId">Id правила типа операции</param>
        public GetRuleByRuleIdQuery(Guid ruleId) 
        {
            RuleId = ruleId;
        }
        /// <summary>
        /// Id правиоа типа операции
        /// </summary>
        public Guid RuleId { get; private set; }
    }
}
