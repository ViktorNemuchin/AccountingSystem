using AccountsTestP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTestP.Data.IRepositories
{
    public interface IAccountHistoryBufferRepository:IRepository<BufferForFutureEntriesDatesModel>
    {
        Task AddBufferEntry(BufferForFutureEntriesDatesModel bufferEntry);
        Task<List<BufferForFutureEntriesDatesModel>> GetAllBufferEntry();
        Task<List<BufferForFutureEntriesDatesModel>> GetBufferEntryForPeriod(DateTime date);
    }
}
