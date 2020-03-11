using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AccountsTestP.Data.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AccountTestPDbContext context) : base(context)
        {

        }

        public async Task<AccountModel> GetAsync(Expression<Func<AccountModel, bool>> predicate)
        {
            return await _context.Accounts.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task AddAccount(AccountModel account)
        {
            await _context.Accounts.AddAsync(account);
        }


        public void Update(AccountModel account)
        {
            _context.Accounts.Update(account);
            _context.Entry(account).State = EntityState.Modified;
        }

    }
}
