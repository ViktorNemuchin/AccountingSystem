using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи данных при добавлении и изменении правила для типа проводки  
    /// </summary>
    public class TransferRuleForRuleControllerDto:TransferRuleDto
    {
        /// <summary>
        /// Дата начала действия данного правила
        /// </summary>
       public DateTimeOffset DateFrom { get; set; }
    }
}
