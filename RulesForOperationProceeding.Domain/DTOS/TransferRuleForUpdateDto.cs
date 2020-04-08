using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для предачи данных при обновлении объектов включающих в себя правила для типа проводок
    /// </summary>
    public class TransferRuleForUpdateDto: TransferRuleDto
    {
        /// <summary>
        /// Id правила
        /// </summary>
        public Guid RuleId { get; set; }

        /// <summary>
        /// Дата начала действия данного правила
        /// </summary>
        public DateTimeOffset DateFrom { get; set; }
    }
}
