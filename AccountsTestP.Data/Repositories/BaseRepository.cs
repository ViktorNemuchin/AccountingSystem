using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return await _context.SaveChangesAsync();
            }
        }
    }
}
