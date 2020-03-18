using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace AccountsTestP.Data.IRepositories
{
    /// <summary>
    /// Класс методов работы с таблицей журнала проводок
    /// </summary>
    public interface IAccountsHistoryRepository : IRepository<AccountHistoryModel>
    {
        /// <summary>
        /// Получение всех проводок в рамках указанной операции по Id операции
        /// </summary>
        /// <param name="operationId">Id операции</param>
        /// <returns>Список проводок операции</returns>
        Task <List<AccountHistoryModel>> GetListForOperationAsync(Guid operationId);
        /// <summary>
        /// Получение всех записей о проводках для конкретного счета из журнала регистрации проводок 
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <returns>Список проводок для конкретного счета</returns>
        Task<List<AccountHistoryModel>> GetListAsync(Guid accountId);
        /// <summary>
        /// Получения списика проводок по счету на основании Linq запроса 
        /// </summary>
        /// <param name="predicate">Linq запрос</param>
        /// <returns>Список проводок</returns>
        Task<AccountHistoryModel> GetAsync(Expression<Func<AccountHistoryModel, bool>> predicate);
        /// <summary>
        /// Получить баланс счета на дату
        /// </summary>
        /// <param name="accountId">Id счета</param>
        /// <param name="date">Дата и время</param>
        /// <returns>Список проводок</returns>
        Task<AccountHistoryModel> GetBalanceByDate(Guid accountId, DateTimeOffset date);
        /// <summary>
        /// Добавить запись о проводке в журнал проводок
        /// </summary>
        /// <param name="account">Запись проводки в журнал проводок</param>
        /// <returns>Запись проводки текущего счета на дату</returns>
        Task AddEntry(AccountHistoryModel account);
        /// <summary>
        /// Получение списика проводок с указанной даты до текущего момента 
        /// </summary>
        /// <param name="startingDate">Дата начала</param>
        /// <param name="sourceAccountId">Id счета дебета</param>
        /// <param name="destinationAccountId">Id счета кредита</param>
        /// <returns> Список проводок</returns>
        IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryFromDate(DateTimeOffset startingDate, Guid sourceAccountId, Guid destinationAccountId);
        /// <summary>
        /// Получение списика проводок с указанной даты до текущего момента 
        /// </summary>
        /// <param name="startingDate">Дата начала</param>
        /// <param name="accountId">Id счета</param>
        /// <returns>Список проводок</returns>
        IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryFromDate(DateTimeOffset startingDate, Guid accountId);
        /// <summary>
        /// Полученик списка проводок до указанной даты
        /// </summary>
        /// <param name="dateBy">Указанная дата</param>
        /// <param name="accountId">Id счета</param>
        /// <returns>Список проводок</returns>
        IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryByDate(DateTimeOffset dateBy, Guid accountId);
        /// <summary>
        /// Удаление списка счетов 
        /// </summary>
        /// <param name="entries"></param>
        void DeleteRangeOfAccountEntries(List<AccountHistoryModel> entries);
        /// <summary>
        /// Удаление указанного счета
        /// </summary>
        /// <param name="accountEntry"></param>
        void DeleteAccountEntry(AccountHistoryModel accountEntry);
        /// <summary>
        /// Внести изменения в список проводок указанных в параметре
        /// </summary>
        /// <param name="entries">Список проводок с изменениями</param>
        void UpdateAccountsEntries(List<AccountHistoryModel> entries);
    }
}
