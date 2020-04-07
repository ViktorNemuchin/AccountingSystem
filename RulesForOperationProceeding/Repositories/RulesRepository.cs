using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.IRepositories;
using System.Threading;

namespace RulesForOperationProceeding.Data.Repositories
{
    /// <summary>
    /// Класса методов работы с правилами типа операций 
    /// </summary>
    public class RulesRepository: BaseRepository, IRuleRepository
    {
        /// <summary>
        /// Конструтор класса методов работы с правилами типа операций 
        /// </summary>
        /// <param name="context">Контекст подключения к БД</param>
        public RulesRepository(RulesForOperationProceedingDataDbContext context) : base(context: context)
        {
            
        }

        /// <summary>
        /// Добавление правила  к типу операции
        /// </summary>
        /// <param name="rule">Правило</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public async Task AddRule(RulesModel rule, CancellationToken ct) => await _context.Rules.AddAsync(rule, ct);

        /// <summary>
        /// Добавлеиие списка правил к типу операции
        /// </summary>
        /// <param name="rules">Список правил</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public async Task AddRules(List<RulesModel> rules, CancellationToken ct) => await _context.Rules.AddRangeAsync(rules, ct);

        /// <summary>
        /// Поиск правила по его Id 
        /// </summary>
        /// <param name="ruleId">ID правила</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Правило для типа операции</returns>
        public async Task<RulesModel> GetRuleEntry(Guid ruleId, CancellationToken ct) => await _context.Rules.AsNoTracking().Where(x => x.Id == ruleId).FirstOrDefaultAsync(ct);

        /// <summary>
        /// Список всех правил для конкретного типа операции
        /// </summary>
        /// <param name="operationId">Id типа операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Список всех правил для типа операции</returns>
        public IAsyncEnumerable<RulesModel> GetRulesForoperationTypeList(Guid operationId, CancellationToken ct) => _context.Rules.AsNoTracking().Where(x => x.OperationTypeId == operationId).AsAsyncEnumerable();

        /// <summary>
        /// Удаление правил для типа операций 
        /// </summary>
        /// <param name="rules">Список правил</param>
        public void DeleteRule(RulesModel rule) => _context.Rules.Remove(rule);

        /// <summary>
        /// Удаление списка правил для типа операций 
        /// </summary>
        /// <param name="rules">Правило с изменениями</param>
        public void DeleteRules(List<RulesModel> rules) => _context.Rules.RemoveRange(rules);

        /// <summary>
        /// Изменение правил для типа операции
        /// </summary>
        /// <param name="rule">Правило с изменениями</param>
        public void UpdateRule(RulesModel rule) => _context.Rules.Update(rule);

        /// <summary>
        /// Изменение списка правил
        /// </summary>
        /// <param name="rules">Список правил с изменениями</param>
        public void UpdateRules(List<RulesModel> rules) => _context.Rules.UpdateRange(rules);


    }
}
