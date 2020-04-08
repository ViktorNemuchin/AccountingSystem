using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    /// <summary>
    /// Интерфес методов для работы с таблицей проводок
    /// </summary>
    public interface IOperationTransferRepository: IBaseRepository
    {
        /// <summary>
        /// Плучение списка проводок по Id лперации
        /// </summary>
        /// <param name="operationId">Id операции</param>
        /// <returns>Список проводок</returns>
        public IAsyncEnumerable<OperationTransferModel> GetTransfersByOerationId(Guid operationId);
        
        /// <summary>
        /// Получение всех зарегистрированных/незарегисрированных прводок
        /// </summary>
        /// <param name="operationId">Id операции</param>
        /// <param name="isRegistered">Флаг регистрации проводок</param>
        /// <returns>Список проводок</returns>
        public IAsyncEnumerable<OperationTransferModel> GetTransferForOperationReistry(Guid operationId, bool isRegistered);
        
        /// <summary>
        /// Добавить проводку
        /// </summary>
        /// <param name="transfer">Проводка</param>
        /// <returns></returns>
        public Task AddTransfer(OperationTransferModel transfer);
        
        /// <summary>
        /// Изменение данных проводки
        /// </summary>
        /// <param name="transfer">Данные для изменения провдоки</param>
        public void UpdateOperation(OperationTransferModel transfer);
        
        /// <summary>
        /// Изменение списка проводок
        /// </summary>
        /// <param name="transfers">Список проводок</param>
        public void UpdateOperations(List<OperationTransferModel> transfers);
        
        /// <summary>
        /// Удаление проводки
        /// </summary>
        /// <param name="transfer">Проводка на удаление</param>
        public void DeleteOperation(OperationTransferModel transfer);
        
        /// <summary>
        /// Удаление списка проводок
        /// </summary>
        /// <param name="transfers">Список проводок</param>
        public void DeleteOperations(List<OperationTransferModel> transfers);
    }
}
