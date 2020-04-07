using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace RulesForOperationProceeding.Data.Repositories
{
    /// <summary>
    /// Класс методов для работы с таблицей операторов
    /// </summary>
    public class OperationTypeRepository: BaseRepository, IOperationTypeRepository
    {
        /// <summary>
        /// Конструктор класса методов для работы с таблицей операторов
        /// </summary>
        /// <param name="context">Контекст подключения к БД</param>
        public OperationTypeRepository(RulesForOperationProceedingDataDbContext context)
            :base(context:context) 
        {

        }
        
        /// <summary>
        /// Добавить тип операции
        /// </summary>
        /// <param name="operationType">Тип операции к добавлению</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public async Task AddOperationType(OperationTypeModel operationType, CancellationToken ct) => await _context.OperationTypes.AddAsync(operationType, ct);
        
        /// <summary>
        /// Добавить список типов операций
        /// </summary>
        /// <param name="operationTypes">Список типа операций</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public async Task AddOperationTypeList(List<OperationTypeModel> operationTypes, CancellationToken ct) => await _context.OperationTypes.AddRangeAsync(operationTypes, ct);
       
        /// <summary>
        /// Поиск типа операции по его идентификатору
        /// </summary>
        /// <param name="operationTypeId">Id операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Тип операции</returns>
        public async Task<OperationTypeModel> GetOperationTypeById(Guid operationTypeId, CancellationToken ct) => await _context.OperationTypes.AsNoTracking().Where(x => x.Id==operationTypeId).FirstOrDefaultAsync(ct);
        
        /// <summary>
        /// Получить все возмодные типы операции
        /// </summary>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Список типов операцйий</returns>
        public IAsyncEnumerable<OperationTypeModel> GetAllOperationtypes(CancellationToken ct) => _context.OperationTypes.AsNoTracking().AsAsyncEnumerable();

        /// <summary>
        /// Изменить тип операции
        /// </summary>
        /// <param name="operationType">Тип измененной операции</param>
        public void UpdateOperationType(OperationTypeModel operationType) => _context.OperationTypes.Update(operationType);
        
        /// <summary>
        /// Удалить тип оерации
        /// </summary>
        /// <param name="operationType">Тип операции для удаления</param>
        public void DeleteOperationType(OperationTypeModel operationType) => _context.OperationTypes.Remove(operationType);
        
        /// <summary>
        /// Поиск типа операции по его названию
        /// </summary>
        /// <param name="operationName">Название операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Тип операции</returns>
        public async Task<OperationTypeModel> GetOperationTypeByName(string operationName, CancellationToken ct) => await _context.OperationTypes.AsNoTracking().Where(x => x.OperationTypeName == operationName).FirstOrDefaultAsync(ct);

    }
}
