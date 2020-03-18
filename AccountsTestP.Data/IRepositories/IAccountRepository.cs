using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    /// <summary>
    /// Класс методов для работы с таблицей счетов
    /// </summary>
    public interface IAccountRepository : IRepository<AccountModel>
    {
        /// <summary>
        /// Добавить новый счет
        /// </summary>
        /// <param name="account"> Счет для добавления</param>
        /// <returns></returns>
        Task AddAccount(AccountModel account);
        /// <summary>
        /// Сделать выборку счетов по Linq запросу
        /// </summary>
        /// <param name="predicate">Linq запрос </param>
        /// <returns></returns>
        Task<AccountModel> GetAsync(Expression<Func<AccountModel, bool>> predicate);
        /// <summary>
        /// Обновить поля записи в таблцие о  счете
        /// </summary>
        /// <param name="account">Счет с новыми  значениями полей</param>
        void Update(List<AccountModel> account);
    }
}
