using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Data.IRepositories;

namespace AccountsTestP.Data.Repositories
{
    public class AccountHistoryBufferRepository: BaseRepository, IAccountHistoryBufferRepository
    {
        public AccountHistoryBufferRepository(AccountTestPDbContext context): base(context) 
        {
        }

        public async Task AddBufferEntry(BufferForFutureEntriesDatesModel bufferEntry) => await _context.Buffer.AddAsync(bufferEntry);
        public async Task<List<BufferForFutureEntriesDatesModel>> GetAllBufferEntry() => await _context.Buffer.ToListAsync();
        public async Task<List<BufferForFutureEntriesDatesModel>> GetBufferEntryForPeriod(DateTime date) => await _context.Buffer.Where(x => DateTime.Compare(x.DueDate.Date, date.Date) == 0).ToListAsync();

    }
}
