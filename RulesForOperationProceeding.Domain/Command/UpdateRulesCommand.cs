using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс конструктора комманды обновления списка правил типа операции
    /// </summary>
    public class UpdateRulesCommand: BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Спсок правил типа операции с внесенными изменениями изменения
        /// </summary>
        public List<RuleDto> RulesForUpdate { get; private set; }

        /// <summary>
        /// Конструктор класса команды обновления списка правил типа операции с внесенными изменениями
        /// </summary>
        /// <param name="rulesForUpdate">Список правил типа операции</param>
        public UpdateRulesCommand(List<RuleDto> rulesForUpdate) => (RulesForUpdate) = (rulesForUpdate);
    }
}
