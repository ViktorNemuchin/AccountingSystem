using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    /// <summary>
    /// Класс модели описывающей схему таблицы параметра операции  
    /// </summary>
    public class OperationParameterModel: BaseModel
    {
        /// <summary>
        /// Назавние параметра операции
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
        /// Конструктор класса модели описывающей схемы таблицы параметра операции для изменения и удаления записи  
        /// </summary>
        /// <param name="id">Id параметра операции</param>
        /// <param name="operationParameterName">Название параметра типа операции</param>
        /// <param name="operationParameterValue">Значение параметра типа операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationParameterModel(Guid id, string operationParameterName, string operationParameterValue, Guid operationTypeId) => 
            (Id, OperationParameterName, OperationParameterValue, OperationTypeId) = (id, operationParameterName, operationParameterValue, operationTypeId);
        /// <summary>
        /// Конструктор класса модели описывающей схему таблицы параметра операции для добавления записи  
        /// </summary>
        /// <param name="operationParameterName">Название параметра типа операции</param>
        /// <param name="operationParameterValue">Значение параметра типа операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationParameterModel(string operationParameterName, string operationParameterValue, Guid operationTypeId) =>
            (OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterName, operationParameterValue, operationTypeId);
    }
}
