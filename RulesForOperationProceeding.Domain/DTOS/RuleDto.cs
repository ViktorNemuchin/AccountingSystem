using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO правил для типа операции
    /// </summary>
    public class RuleDto
    {
        /// <summary>
        /// Id правила
        /// </summary>
        public Guid RuleId { get; set; }
        /// <summary>
        /// Счет дебета
        /// </summary>
        public string SourceAccount { get; set; }

        /// <summary>
        /// Счет кредита
        /// </summary>
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Порядковый номер правила
        /// </summary>
        public int RuleOrderNumber { get; set; }

        /// <summary>
        /// Формула расчета суммы проводки
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата начала действия правила
        /// </summary>
        public DateTimeOffset DateFrom { get; set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }
    }
}
