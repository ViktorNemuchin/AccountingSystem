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
           
            var dayDate = date.Date;

            var entries = await _context.AccountHistory.AsNoTracking().Where(x => x.DestinationAccountId == accountId || x.SourceAccountId == accountId).ToListAsync();

            return entries.Where(x => x.DueDate.Date == dayDate).LastOrDefault(); 
        }

        public IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryFromDate(DateTimeOffset startingDate, Guid sourceAccountId, Guid destinationAccountId) => _context.AccountHistory.AsNoTracking().Where(x => x.DueDate > startingDate).Where(x=>x.DestinationAccountId == sourceAccountId  || x.DestinationAccountId == destinationAccountId || x.SourceAccountId == sourceAccountId || x.SourceAccountId == destinationAccountId).AsAsyncEnumerable();
        public IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryFromDate(DateTimeOffset startingDate, Guid accountId) => _context.AccountHistory.AsNoTracking().Where(x => x.DestinationAccountId == accountId | x.SourceAccountId == accountId && x.DueDate > startingDate).AsAsyncEnumerable();
        public IAsyncEnumerable<AccountHistoryModel> GetAccountHistoryByDate(DateTimeOffset dateBy, Guid accountId) => _context.AccountHistory.AsNoTracking().Where(x => x.DestinationAccountId == accountId | x.SourceAccountId == accountId && x.DueDate <= dateBy).AsAsyncEnumerable();
        public void DeleteRangeOfAccountEntries(List<AccountHistoryModel> accountEntriesToDelete) => _context.AccountHistory.RemoveRange(accountEntriesToDelete);
        public void DeleteAccountEntry(AccountHistoryModel accountEntry) => _context.Remove(accountEntry);

        public void UpdateAccountsEntries(List<AccountHistoryModel> entries) =>_context.UpdateRange(entries);

        

        public async Task<List<AccountHistoryModel>> GetListAsync(Guid accountId) => await _context.AccountHistory.AsNoTracking().Where(x => x.SourceAccountId == accountId || x.DestinationAccountId == accountId).OrderBy(x=>x.DueDate).ToListAsync();

        public async Task<List<AccountHistoryModel>> GetListForOperationAsync(Guid operationId) => await _context.AccountHistory.AsNoTracking().Where(x => x.OperationId == operationId).ToListAsync();
        public async Task AddEntry(AccountHistoryModel entry) => await _context.AccountHistory.AddAsync(entry);
 


    }
}
