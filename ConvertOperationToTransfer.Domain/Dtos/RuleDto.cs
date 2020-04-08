using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Dtos
{
    /// <summary>
    /// Класс DTO правил
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
        /// Порядковый номер правила в списке правил
        /// </summary>
        public int RuleOrderNumber { get; set; }

        /// <summary>
        /// Формула вычисления суммы проводки
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Дата начала действия операции
        /// </summary>
        public DateTimeOffset DateFrom { get; set; }
        
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }
    }
}
