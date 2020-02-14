using AccountsTestP.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountRepository : IRepository<AccountModel>
    {
        Task AddAccount(AccountModel account);
        Task<AccountModel> GetAsync(Expression<Func<AccountModel, bool>> predicate);
        void Update(AccountModel account);
    }
}
