using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды удаления параметра
    /// </summary>
    public class DeleteOperationParameterCommand : BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id параметра операции
        /// </summary>
        public Guid OperationParameterId { get; private set; }
        /// <summary>
        /// Конструктор класса команды удаления параметра
        /// </summary>
        /// <param name="operationParameterId">Id параметра типа операции </param>
        public DeleteOperationParameterCommand(Guid operationParameterId) => (OperationParameterId) = (operationParameterId);
    }
}
