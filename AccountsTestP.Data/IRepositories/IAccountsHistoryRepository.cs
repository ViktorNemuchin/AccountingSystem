using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Domain.Models;
using System.Linq;
using System.Linq.Expressions;


namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountsHistoryRepository: IRepository<AccountHistoryModel>
    {
        Task<List<AccountHistoryModel>> GetListAsync(int accountId);
        Task<AccountHistoryModel> GetAsync(Expression<Func<AccountHistoryModel, bool>> predicate);
        Task AddEntry(AccountHistoryModel account);

    }
}
