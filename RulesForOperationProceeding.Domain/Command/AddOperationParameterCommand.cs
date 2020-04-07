using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды добавления параметра операции
    /// </summary>
    public class AddOperationParameterCommand:BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Название параметра операции
        /// </summary>
        public string OperationParameterName { get; private set; }

        /// <summary>
        /// Значение параметра операции
        /// </summary>
        public string OperationParameterValue { get; private set; }

        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }

        /// <summary>
        /// Конструктор команды добавления параметра операции
        /// </summary>
        /// <param name="operationParameterName">Название операции</param>
        /// <param name="operationParameterValue">Значение параметра операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public AddOperationParameterCommand(string operationParameterName, string operationParameterValue, Guid operationTypeId) => 
            (OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterName, operationParameterValue, operationTypeId);
    }
}
