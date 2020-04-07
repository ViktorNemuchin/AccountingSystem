using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи данных при обновлении типа операции
    /// </summary>
    public class UpdateOperationTypeTransferDto
    {
        /// <summary>
        /// Названиие типа операции
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// Спсиок параметров типа операции
        /// </summary>
        public List<TransferOperationParameterForUpdateDto> OperationParameters { get; set; }

        /// <summary>
        /// Список правил типа операции
        /// </summary>
        public List<TransferRuleForUpdateDto> Rules { get; set; }
    }
}
