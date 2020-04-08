using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Dtos
{
    /// <summary>
    /// Класс DTO параметра операции
    /// </summary>
    public class OperationParameterDto
    {
        /// <summary>
        /// Id параметра операции
        /// </summary>
        public Guid OperationParameterId { get; set; }
        
        /// <summary>
        /// Название параметра операции
        /// </summary>
        public string OperationParameterName { get; set; }
        
        /// <summary>
        /// Значение параметра операции
        /// </summary>
        public string OperationParameterValue { get; set; }
        
        /// <summary>
        /// Id операции
        /// </summary>
        public Guid OperationId { get; set; }

    }
}
