using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.Repositories
{
    public class BaseRepository: IBaseRepository
    {
        private readonly RulesForOperationProceedingDataDbContext _context;
        public BaseRepository(RulesForOperationProceedingDataDbContext context)
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
