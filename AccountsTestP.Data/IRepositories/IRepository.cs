using AccountsTestP.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
