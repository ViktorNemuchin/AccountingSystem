using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Dtos
{
    public class TransferOperationDto
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
        /// Формула вычисления суммы проводки
        /// </summary>
        public string Ammount { get; set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата применения проводки
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationId { get; set; }
    }
}
