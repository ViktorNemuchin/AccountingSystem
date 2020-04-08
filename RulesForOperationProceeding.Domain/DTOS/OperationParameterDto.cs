using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс дто параметров операции
    /// </summary>
    public class OperationParameterDto
    {
        /// <summary>
        /// Id параметра типа операции
        /// </summary>
        public Guid OperationParameterId { get; set; }

        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationParameterName { get; set; }

        /// <summary>
        /// Значение типа операции
        /// </summary>
        public string OperationParameterValue { get; set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; set; }

    }
}
