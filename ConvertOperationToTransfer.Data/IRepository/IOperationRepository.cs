using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    /// <summary>
    /// Интерфейс для работы с операциями
    /// </summary>
    public interface IOperationRepository: IBaseRepository
    {
        /// <summary>
        /// Получение операции по Id
        /// </summary>
        /// <param name="operationId">Id лперации</param>
        /// <returns>Операция</returns>
        public Task<OperationModel> GetOperationById(Guid operationId);
        
        /// <summary>
        /// Получение списка всех операций
        /// </summary>
        /// <returns>Список всех  операций</returns>
        public IAsyncEnumerable<OperationModel> GetAllOperations();
        
        /// <summary>
        /// Создание операции
        /// </summary>
        /// <param name="operation">Новая операция</param>
        /// <returns></returns>
        public Task AddOperation(OperationModel operation);
        
        /// <summary>
        /// Изменение операции
        /// </summary>
        /// <param name="operation">Операция с изменными данными</param>
        public void UpdateOperation(OperationModel operation);
       
        /// <summary>
        /// Изменение списка операции
        /// </summary>
        /// <param name="operations">Спиисок операции с изменными данными</param>
        public void UpdateOperations(List<OperationModel> operations);
        
        /// <summary>
        /// Удаление операции
        /// </summary>
        /// <param name="operation">Операция для удаления</param>
        public void DeleteOperation(OperationModel operation);

        /// <summary>
        /// Удаление списка операции
        /// </summary>
        /// <param name="operations">Список операции для удаления</param>
        public void DeleteOperations(List<OperationModel> operations);
    }
}
