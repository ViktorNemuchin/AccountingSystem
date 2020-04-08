using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи передача данных о правилах для типа проводки 
    /// </summary>
    public class TransferRuleDto
    {
        /// <summary>
        /// Счет дебета
        /// </summary>
        public string SourceAccount { get; set; }

        /// <summary>
        /// Счет кредита
        /// </summary>
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Порядковый номер правила в списке
        /// </summary>
        public int RuleOrderNumber { get; set; }

        /// <summary>
        /// Формула для вычисления суммы проводки
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Описание проводки
        /// </summary>
        public string Description { get; set; }
    }
}
