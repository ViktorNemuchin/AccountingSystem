using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountRepository: IRepository<AccountModel>
    {
        Task<AccountModel> GetAsync(Expression<Func<AccountModel, bool>> predicate);
        void Update(AccountModel account);
    }
}
