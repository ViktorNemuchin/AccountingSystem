using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO типа операции
    /// </summary>
    public class OperationTypeDto
    {
        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// Список параметров типа операции
        /// </summary>
        public List<OperationParameterDto> OperationParameters { get; set; }

        /// <summary>
        /// Список правил типа операции
        /// </summary>
        public List<RuleDto> Rules{get;set;}
    }
}
