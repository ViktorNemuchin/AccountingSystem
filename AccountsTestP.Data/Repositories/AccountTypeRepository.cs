using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsTestP.Data.Repositories
{
    public class AccountTypeRepository:BaseRepository, IAccountTypeRepository
    {
        public AccountTypeRepository(AccountTestPDbContext context): base(context) 
        {
        }

        public async Task<AccountTypeModel> GetAccountType(int AccountTypeId) => await _context.AccountTypes.AsNoTracking()
            .Where(x=>x.AccountTypeNumber ==AccountTypeId)
            .FirstOrDefaultAsync();
        public async Task<List<AccountTypeModel>> GetAllAccountTypes() => await _context.AccountTypes.AsNoTracking().ToListAsync();

    }
}
