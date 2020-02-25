using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountsHistoryRepository : IRepository<AccountHistoryModel>
    {
        Task <List<AccountHistoryModel>> GetListForOperationAsync(Guid operationId);
        Task<List<AccountHistoryModel>> GetListAsync(Guid accountId);
        Task<AccountHistoryModel> GetAsync(Expression<Func<AccountHistoryModel, bool>> predicate);
        Task<AccountHistoryModel> GetBalanceByDate(Guid accountId, DateTimeOffset date);
        Task AddEntry(AccountHistoryModel account);

    }
}
