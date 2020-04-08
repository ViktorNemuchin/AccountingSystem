using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    /// <summary>
    /// Класс модели описывающей схему таблицы типа операции
    /// </summary>
    public class OperationTypeModel: BaseModel
    {
        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; private set; }

        /// <summary>
        /// Конструктор модели описывающей схему таблицы типа операции для изменения или удаления записи
        /// </summary>
        /// <param name="id">Id типа операции</param>
        /// <param name="operationTypeName">Название типа операции</param>
        public OperationTypeModel(Guid id, string operationTypeName) => (Id, OperationTypeName) = (id, operationTypeName);

        /// <summary>
        /// Конструктор модули типа операции описывающей схему таблицы типа операции для добавления записи
        /// </summary>
        /// <param name="operationTypeName">Название типа операции</param>
        public OperationTypeModel(string operationTypeName) => (OperationTypeName) = (operationTypeName);
    }
}

