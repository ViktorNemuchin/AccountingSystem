using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды удаления правила типа операции
    /// </summary>
    public class DeleteRuleCommand:BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id правила операции для удаления
        /// </summary>
        public Guid RuleId { get; private set; }

        /// <summary>
        /// Конструктор класса команды удаления типа операции 
        /// </summary>
        /// <param name="ruleId">Id правила операции</param>
        public DeleteRuleCommand(Guid ruleId) => (RuleId) = (ruleId);
    }
}
