using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    /// <summary>
    /// Класс модели описания схемы проводки
    /// </summary>
    public class OperationTransferModel:BaseModel
    {
        /// <summary>
        /// Счет дебета
        /// </summary>
        public string SourceAcount { get; private set; }
        
        /// <summary>
        /// Счет кредита
        /// </summary>
        public string DestinationAccount { get; private set; }
        
        /// <summary>
        /// Дата влияния проводки на расчеты
        /// </summary>
        public DateTimeOffset DueDate { get; private set; }
        
        /// <summary>
        /// Сумма проводки
        /// </summary>
        public decimal Ammount { get; private set; } 
        
        /// <summary>
        /// Описание проводки
        /// </summary>
        public string Description { get; private set; }
        
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; private set; }
        
        /// <summary>
        /// Флаг регистрации проводки
        /// </summary>
        public bool IsRegistered { get; private set; }
    }
}
