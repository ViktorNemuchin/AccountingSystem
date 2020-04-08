using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesForOperationProceeding.Data.IRepositories;
using System.Threading;

namespace RulesForOperationProceeding.Data.Repositories
{
    /// <summary>
    /// Контекст методов работы с таблицей параметров операций
    /// </summary>
    public class OperationParameterRepository:BaseRepository, IOperationParameterRepositor
    {

        /// <summary>
        /// Конструктор класса работы с таблицей параметров операций
        /// </summary>
        /// <param name="context">Контекст подключения к БД</param>
        public OperationParameterRepository(RulesForOperationProceedingDataDbContext context)
            : base(context: context)
        {
        }
        /// <summary>
        /// Добавить парамметр к указанной операции 
        /// </summary>
        /// <param name="operationParameter">параметр для добавления</param>
        /// <param name="cts">Токен отмены</param>
        /// <returns></returns>
        public async Task AddOperationParameter(OperationParameterModel operation, CancellationToken ct) =>  await _context.OperationParameters.AddAsync(operation,ct);
        /// <summary>
        /// Добавить список параметров к указанному типу операций
        /// </summary>
        /// <param name="operations">Список операций</param>
        /// <param name="cts">Токен отмены</param>
        /// <returns></returns>
        public async Task AddOperationParameters (List<OperationParameterModel> operations, CancellationToken ct) => await _context.OperationParameters.AddRangeAsync(operations, ct);
        /// <summary>
        /// Получение списка входящих пармметров типа операции 
        /// </summary>
        /// <param name="operationyTypeId">Id типа операции</param>
        /// <param name="ct">Токен отмены </param>
        /// <returns>Список всех парраметров для типа операции</returns>
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersById(Guid operationyTypeId, CancellationToken cts) => _context.OperationParameters.AsNoTracking().Where(x => x.OperationTypeId == operationyTypeId).AsAsyncEnumerable();
        /// <summary>
        /// Получение параметра  по его идентификатеру
        /// </summary>
        /// <param name="operationParameterId"> Id парамметра</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Параметр операции </returns>
        public async Task<OperationParameterModel> GetOperationParameter(Guid operationParameterId, CancellationToken cts) => await _context.OperationParameters.AsNoTracking().Where(x => x.Id == operationParameterId).FirstOrDefaultAsync(cts);
        /// <summary>
        /// Обновить параметр операции
        /// </summary>
        /// <param name="operationParameter">Данные для обновления</param>
        public void UpdateOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Update(operationParameter);
        /// <summary>
        /// Обновить список операций
        /// </summary>
        /// <param name="operationParameters">Список изменных параметров</param>
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters) => _context.OperationParameters.UpdateRange(operationParameters);
        /// <summary>
        /// Удалить параметр операции
        /// </summary>
        /// <param name="operationParameter">Параметр операции для добавления</param>
        public void DeleteOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Remove(operationParameter);
    }
}
