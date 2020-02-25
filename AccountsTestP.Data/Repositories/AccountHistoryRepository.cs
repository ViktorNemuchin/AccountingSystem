using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks.Sources;
using System.Threading.Tasks;

namespace AccountsTestP.Data.Repositories
{
    public class AccountHistoryRepository : BaseRepository, IAccountsHistoryRepository
    {

        public AccountHistoryRepository(AccountTestPDbContext context) : base(context)
        {

        }

        public async Task<AccountHistoryModel> GetAsync(Expression<Func<AccountHistoryModel, bool>> predicate) => await _context.AccountHistory.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        public async Task<AccountHistoryModel> GetBalanceByDate(Guid accountId, DateTimeOffset date)
        {
            var ddate = date.Date;

            var entries = await _context.AccountHistory.Where(x => x.DestinationAccountId == accountId || x.SourceAccountId == accountId).ToListAsync();

            return entries.Where(x => x.DueDate.Date == ddate).FirstOrDefault(); 
        } 

        public async Task<List<AccountHistoryModel>> GetListAsync(Guid accountId) => await _context.AccountHistory.AsNoTracking().Where(x => x.SourceAccountId == accountId || x.DestinationAccountId == accountId).ToListAsync();

        public async Task<List<AccountHistoryModel>> GetListForOperationAsync(Guid operationId) => await _context.AccountHistory.AsNoTracking().Where(x => x.OperationId == operationId).ToListAsync();
        public async Task AddEntry(AccountHistoryModel entry) => await _context.AccountHistory.AddAsync(entry);
 


    }
}
