using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// Класс DTO для передачи параметров результата выполнения команды 
    /// </summary>
    public class TransferResultDto
    {
        /// <summary>
        /// Id объекта
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название объекта
        /// </summary>
        public string Name { get; set; }
    }
}
