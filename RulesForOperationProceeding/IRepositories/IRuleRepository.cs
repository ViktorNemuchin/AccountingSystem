using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    /// <summary>
    /// Интерфейс класса методов работы с правилами типа операций 
    /// </summary>
    public interface  IRuleRepository: IBaseRepository
    {
        /// <summary>
        /// Добавление правила  к типу операции
        /// </summary>
        /// <param name="rule">Правило</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public Task AddRule(RulesModel rule, CancellationToken ct);
        /// <summary>
        /// Добавлеиие списка правил к типу операции
        /// </summary>
        /// <param name="rules">Список правил</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns></returns>
        public Task AddRules(List<RulesModel> rules, CancellationToken ct);
        /// <summary>
        /// Поиск правила по его Id 
        /// </summary>
        /// <param name="ruleId">ID правила</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Правило для типа операции</returns>
        public Task<RulesModel> GetRuleEntry(Guid ruleId, CancellationToken ct);
        /// <summary>
        /// Список всех правил для конкретного типа операции
        /// </summary>
        /// <param name="operationId">Id типа операции</param>
        /// <param name="ct">Токен отмены</param>
        /// <returns>Список всех правил для типа операции</returns>
        public IAsyncEnumerable<RulesModel> GetRulesForoperationTypeList(Guid operationId, CancellationToken ct);
        /// <summary>
        /// Удаление правила из списка правил
        /// </summary>
        /// <param name="rule">Правило для удаления</param>
        public void DeleteRule(RulesModel rule);
        /// <summary>
        /// Удаление списка правил для типа операций 
        /// </summary>
        /// <param name="rules">Список правил</param>
        public void DeleteRules(List<RulesModel> rules);
        /// <summary>
        /// Изменение правил для типа операции
        /// </summary>
        /// <param name="rule">Правило с изменениями</param>
        public void UpdateRule(RulesModel rule);
        /// <summary>
        /// Изменение списка правил
        /// </summary>
        /// <param name="rules">Список правил с изменениями</param>
        public void UpdateRules(List<RulesModel> rules);
    }
}
