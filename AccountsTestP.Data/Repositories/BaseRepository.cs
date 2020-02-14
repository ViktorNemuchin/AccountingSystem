using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using System;
using System.Threading.Tasks;

namespace AccountsTestP.Data.Repositories
{
    public class BaseRepository : IRepository<BaseModel>
    {
        protected readonly AccountTestPDbContext _context;
        public BaseRepository(AccountTestPDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(); ;
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges() 
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
