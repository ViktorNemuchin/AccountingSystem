using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO типа операции (не детальный)
    /// </summary>
    public class OperationTypeForListDto
    {
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationtypeId { get; set; }

        /// <summary>
        /// Назвние операции
        /// </summary>
        public string OperationTypeName { get; set; }
    }
}
