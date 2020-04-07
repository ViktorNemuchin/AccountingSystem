using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи параметров операции 
    /// </summary>
    public class TransferOperationParameterDto
    {
        /// <summary>
        /// Название параметра операции
        /// </summary>
        public string OperationParameterName { get; set; }

        /// <summary>
        /// Значение параметра операции
        /// </summary>
        public string OperationParameterValue { get; set; }
    }
}
