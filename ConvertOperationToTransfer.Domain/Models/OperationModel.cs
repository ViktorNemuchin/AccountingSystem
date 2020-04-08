using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    /// <summary>
    /// Класс модели операции
    /// </summary>
    public class OperationModel: BaseModel
    {
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }
        
        /// <summary>
        /// Дата начала применения операции
        /// </summary>
        public DateTimeOffset DueDate { get; private set; }
        
        /// <summary>
        /// Флаг регистрации операции
        /// </summary>
        public bool IsRegistered { get; private set; }
        
        /// <summary>
        /// Название типа операциии
        /// </summary>
        public string OperationTypeName { get; private set; }

        /// <summary>
        /// Конструктор класса операции для изменения или удаления
        /// </summary>
        /// <param name="id">Id операции</param>
        /// <param name="operationTypeName">Название типа операции</param>
        /// <param name="isRegistered">Флаг регистрации операции</param>
        /// <param name="dueDate">Дата начала применения операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationModel(Guid id, string operationTypeName, bool isRegistered, DateTimeOffset dueDate, Guid operationTypeId) => (Id, OperationTypeName, IsRegistered, DueDate,OperationTypeId) = (id, operationTypeName, isRegistered, dueDate, operationTypeId);

        /// <summary>
        /// Конструктор класса операции для добавления операции
        /// </summary>
        /// <param name="operationTypeName">Название типа операции</param>
        /// <param name="isRegistered">Флаг регистрации операции</param>
        /// <param name="dueDate">Дата начала применения операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        public OperationModel(string operationTypeName, bool isRegistered, DateTimeOffset dueDate, Guid operationTypeId) => (OperationTypeName, IsRegistered, DueDate, OperationTypeId) = (operationTypeName, isRegistered, dueDate, operationTypeId);

    }
}
