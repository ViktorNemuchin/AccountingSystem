using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Dtos
{
   /// <summary>
   /// Dto Операции
   /// </summary>
    public class OperationDto
    {
        /// <summary>
        /// Название операции
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// Список параметров операции
        /// </summary>
        public List<OperationParameterDto> OperationParameters { get; set; }

        /// <summary>
        /// Список правил операции
        /// </summary>
        public List<RuleDto> Rules { get; set; }
    }
}
