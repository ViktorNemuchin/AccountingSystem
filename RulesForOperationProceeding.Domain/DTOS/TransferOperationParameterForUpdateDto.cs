using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи данных при изменении параметров DTO
    /// </summary>
    public class TransferOperationParameterForUpdateDto:TransferOperationParameterDto
    {
        /// <summary>
        /// Id параметра операции
        /// </summary>
        public Guid OperationParameterId { get; set; }
    }
}
