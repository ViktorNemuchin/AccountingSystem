using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    /// <summary>
    /// Интерфейс методов для работы с таблицей параметров для опреации
    /// </summary>
    public interface IOperationParameterRepository:IBaseRepository
    {
        /// <summary>
        /// Получить все параметры по Id операции
        /// </summary>
        /// <param name="operationId">Id операции</param>
        /// <returns>Список параметров операции</returns>
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersByOperationId(Guid operationId);
        
        /// <summary>
        /// Добавить параметр к операции
        /// </summary>
        /// <param name="operationParameter">Параметр операции</param>
        /// <returns></returns>
        public Task AddOperationParameter(OperationParameterModel operationParameter);
        
        /// <summary>
        /// Изменть параметр операции
        /// </summary>
        /// <param name="operationParameter">Прамаетр с измененными данными</param>
        public void UpdateOperationParameter(OperationParameterModel operationParameter);
        
        /// <summary>
        /// Изменить список параметров операции
        /// </summary>
        /// <param name="operationParameters">Список прараметров для операции</param>
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters);

        /// <summary>
        /// Удалить параметр операции
        /// </summary>
        /// <param name="operationParameter"><параметр операции для удаления/param>
        public void DeleteOperationParameter(OperationParameterModel operationParameter);
        
        /// <summary>
        /// Удалить спписок параметров
        /// </summary>
        /// <param name="operationParameters">Список параметров на удаление</param>
        public void DeleteOperationParameters(List<OperationParameterModel> operationParameters);
    }
}
