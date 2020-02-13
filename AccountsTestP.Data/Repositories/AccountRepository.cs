using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Models;
using AccountsTestP.Data.IRepositories;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using AccountsTestP.Data.AccountDbContext;
using Microsoft.EntityFrameworkCore;
namespace AccountsTestP.Data.Repositories
{
    public class AccountRepository : BaseRepository,  IAccountRepository
    {
        public AccountRepository(AccountTestPDbContext context) :base(context) 
        {
           
        }

        public async Task<AccountModel> GetAsync(Expression<Func<AccountModel, bool>> predicate)
        {
            return await _context.Accounts.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }


       

        public void Update(AccountModel account)
        {
            _context.Accounts.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
        }
    }
}
