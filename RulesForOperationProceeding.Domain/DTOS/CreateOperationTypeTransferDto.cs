using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
   /// <summary>
   /// Класс DTO типа операции для получения данных о создании операции
   /// </summary>
    public class OperationTypeTransferDto
    {
        /// <summary>
        /// Тип операции
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// Список параметров типа операции
        /// </summary>
        public List<TransferOperationParameterDto> OperationParameters { get; set; }

        /// <summary>
        /// Список правил типа операции
        /// </summary>
        public List<TransferRuleDto> Rules { get; set; }

        /// <summary>
        /// Дата начала действия операции
        /// </summary>
        public DateTimeOffset DateFrom { get; set; }
    }
}
