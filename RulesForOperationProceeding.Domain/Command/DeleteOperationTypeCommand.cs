using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды удаления типа операции 
    /// </summary>
    public class DeleteOperationTypeCommand:BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id типа операции для удаления
        /// </summary>
        public Guid OperationTypeId { get; private set; }
        /// <summary>
        /// Конструтор класса команды удаления типа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        public DeleteOperationTypeCommand(Guid operationTypeId) => (OperationTypeId)=(operationTypeId);
    }
}
