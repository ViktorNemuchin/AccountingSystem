using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertOperationToTransfer.Data.ConvertOperationsDbContext;
using ConvertOperationToTransfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConvertOperationToTransfer.Data.Repository
{
    public class OperationTransferRepository:BaseRepository
    {
        public OperationTransferRepository(ConvertOperationToTransferDbContext context)
            : base(context: context) { }

        public IAsyncEnumerable<OperationTransferModel> GetTransfersByOerationId(Guid operationId) => _context.Transfers.AsNoTracking().Where(x => x.Id == operationId).AsAsyncEnumerable();
        public IAsyncEnumerable<OperationTransferModel> GetTransferForOperationReistry(Guid operationId, bool isRegistered) => _context.Transfers.AsNoTracking().Where(x => x.Id == operationId || x.IsRegistered == isRegistered).AsAsyncEnumerable();
        public async Task AddTransfer(OperationTransferModel transfer) => await _context.Transfers.AddAsync(transfer);
        public void UpdateOperation(OperationTransferModel transfer) => _context.Transfers.Update(transfer);
        public void UpdateOperations(List<OperationTransferModel> transfers) => _context.Transfers.UpdateRange(transfers);
        public void DeleteOperation(OperationTransferModel transfer) => _context.Transfers.Remove(transfer);
        public void DeleteOperations(List<OperationTransferModel> transfers) => _context.Transfers.RemoveRange(transfers);
    }
}
