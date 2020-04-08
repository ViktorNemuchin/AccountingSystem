using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    /// <summary>
    /// Класс модели описания схемы таблицы параметров операции
    /// </summary>
    public class OperationParameterModel: BaseModel
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
        /// Конструктор класса модели описания схемы таблицы параметров операции для изменения и удаления
        /// </summary>
        /// <param name="id">Id типа операции</param>
        /// <param name="operationParameterName">Название параметра операции</param>
        /// <param name="operationParameterValue">Название значения параметра операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationParameterModel(Guid id, string operationParameterName, string operationParameterValue, Guid operationTypeId) =>
            (Id, OperationParameterName, OperationParameterValue, OperationTypeId) = (id, operationParameterName, operationParameterValue, operationTypeId);

        /// <summary>
        /// Конструктор класса модели описания схемы таблицы параметров операции для добавления
        /// </summary>
        /// <param name="operationParameterName">Название параметра операции</param>
        /// <param name="operationParameterValue">Название значения параметра операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationParameterModel(string operationParameterName, string operationParameterValue, Guid operationTypeId) =>
            (OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterName, operationParameterValue, operationTypeId);
    }
}
