using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertOperationToTransfer.Data.IRepository;
using ConvertOperationToTransfer.Data.ConvertOperationsDbContext;
using Microsoft.EntityFrameworkCore;

namespace ConvertOperationToTransfer.Data.Repository
{
    public class BaseRepository:IBaseRepository
    {
        protected readonly ConvertOperationToTransferDbContext _context;
        public BaseRepository(ConvertOperationToTransferDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(); 
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
