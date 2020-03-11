using AccountsTestP.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    /// <summary>
    /// Базовый класс методов для работы с таблицами Бд модуля регистрации проводок
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        /// <summary>
        /// Сохранить изменения асинхронно
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// Сохранить изменения синхронно
        /// </summary>
        void SaveChanges();
    }
}
