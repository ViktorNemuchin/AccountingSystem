using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    /// <summary>
    /// Интерфейс работы с типами операции
    /// </summary>
    public interface IOperationTypeRepository: IBaseRepository
    {
        /// <summary>
        /// Добавить тип операции
        /// </summary>
        /// <param name="operationType">Тип операции к добавлению</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public Task AddOperationType(OperationTypeModel operationType, CancellationToken ct);
        /// <summary>
        /// Добавить список типов операций
        /// </summary>
        /// <param name="operationTypes">Список типа операций</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public Task AddOperationTypeList(List<OperationTypeModel> operationTypes, CancellationToken ct);
        /// <summary>
        /// Поиск типа операции по его идентификатору
        /// </summary>
        /// <param name="operationTypeId">Id операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Тип операции</returns>
        public Task<OperationTypeModel> GetOperationTypeById(Guid operationTypeId, CancellationToken ct);
        /// <summary>
        /// Поиск типа операции по его названию
        /// </summary>
        /// <param name="operationName">Название операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Тип операции</returns>
        public Task<OperationTypeModel> GetOperationTypeByName(string operationName, CancellationToken ct);
        /// <summary>
        /// Получить все возмодные типы операции
        /// </summary>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Список типов операцйий</returns>
        public IAsyncEnumerable<OperationTypeModel> GetAllOperationtypes(CancellationToken ct);
        /// <summary>
        /// Изменить тип операции
        /// </summary>
        /// <param name="operationType">Тип измененной операции</param>
        public void UpdateOperationType(OperationTypeModel operationType);
        /// <summary>
        /// Удалить тип оерации
        /// </summary>
        /// <param name="operationType">Тип операции для удаления</param>
        public void DeleteOperationType(OperationTypeModel operationType);
    }
}
