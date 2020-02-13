using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsTestP.Data.Repositories
{
    public class AccountHistoryRepository: BaseRepository, IAccountsHistoryRepository
    {

        public AccountHistoryRepository(AccountTestPDbContext context) : base(context)
        {

        }

        public async Task<AccountHistoryModel> GetAsync(Expression<Func<AccountHistoryModel, bool>> predicate) => await _context.AccountHistory.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        

        public async Task<List<AccountHistoryModel>> GetListAsync(int accountId) => await _context.AccountHistory.AsNoTracking().Where(x => x.AccountId == accountId).ToListAsync();
        

        public async Task AddEntry (AccountHistoryModel entry)
        {
           await  _context.AccountHistory.AddAsync(entry);
        }

       
    }
}
