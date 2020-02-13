using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using AccountsTestP.Data.AccountDbContext;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Data.Repositories
{
    public class BaseRepository : IRepository<BaseModel>
    {
        protected readonly AccountTestPDbContext _context; 
        public BaseRepository(AccountTestPDbContext context )
        { 
            _context = context ?? throw new ArgumentNullException(); ; 
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
