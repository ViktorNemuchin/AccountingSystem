using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    /// <summary>
    /// Интерфейс класса методов работы с параметрами типа операции
    /// </summary>
    public interface IOperationParameterRepositor:IBaseRepository
    {
        /// <summary>
        /// Получение списка входящих пармметров типа операции 
        /// </summary>
        /// <param name="operationyTypeId">Id типа операции</param>
        /// <param name="ct">Токен отмены </param>
        /// <returns>Список всех парраметров для типа операции</returns>
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersById(Guid operationyTypeId, CancellationToken ct);
        /// <summary>
        /// Получение параметра  по его идентификатеру
        /// </summary>
        /// <param name="operationParameterId"> Id парамметра</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Параметр операции </returns>
        public Task<OperationParameterModel> GetOperationParameter(Guid operationParameterId,  CancellationToken ct);
        /// <summary>
        /// Добавить парамметр к указанной операции 
        /// </summary>
        /// <param name="operationParameter">параметр для добавления</param>
        /// <param name="cts">Токен отмены</param>
        /// <returns></returns>
        public Task AddOperationParameter(OperationParameterModel operationParameter, CancellationToken cts);
        /// <summary>
        /// Добавить список параметров к ууказанному типу операций
        /// </summary>
        /// <param name="operations">Список операций</param>
        /// <param name="cts">Токен отмены</param>
        /// <returns></returns>
        public Task AddOperationParameters(List<OperationParameterModel> operations, CancellationToken cts);
        /// <summary>
        /// Обновить параметр операции
        /// </summary>
        /// <param name="operationParameter">Данные для обновления</param>
        public void UpdateOperationParameter(OperationParameterModel operationParameter);
        /// <summary>
        /// Обновить список операций
        /// </summary>
        /// <param name="operationParameters">Список изменных параметров</param>
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters);
        /// <summary>
        /// Удалить параметр операции
        /// </summary>
        /// <param name="operationParameter">Параметр операции для добавления</param>
        public void DeleteOperationParameter(OperationParameterModel operationParameter); 
    }
}
