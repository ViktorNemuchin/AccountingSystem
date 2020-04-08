using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды изменения параметра типа операции
    /// </summary>
    public class UpdateOperationParameterCommand: BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id параметра операции
        /// </summary>
        public Guid OperationParameterId { get; private set; }

        /// <summary>
        /// Название параметра операции
        /// </summary>
        public string OperationParameterName { get; private set; }

        /// <summary>
        ///  Значение параметра операции
        /// </summary>
        public string OperationParameterValue { get; private set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }

        /// <summary>
        /// Конструктор класса изменения параметра операции
        /// </summary>
        /// <param name="operationParameterId">Id параметра операции</param>
        /// <param name="operationParameterName">Название параметра операции</param>
        /// <param name="operationParameterValue">Значение параметра операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public UpdateOperationParameterCommand(Guid operationParameterId, string operationParameterName, string operationParameterValue, Guid operationTypeId) => 
            (OperationParameterId, OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterId, operationParameterName, operationParameterValue, operationTypeId); 
    }
}
