using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertOperationToTransfer.Data.ConvertOperationsDbContext;
using ConvertOperationToTransfer.Data.IRepository;
using ConvertOperationToTransfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConvertOperationToTransfer.Data.Repository
{
    public class OperationRepository:BaseRepository,IOperationRepository
    {
        public OperationRepository(ConvertOperationToTransferDbContext context) 
            : base(context:context)
        { }

        public async Task<OperationModel> GetOperationById(Guid operationId) => await _context.Operations.AsNoTracking().Where(x => x.Id == operationId).FirstOrDefaultAsync();
        public IAsyncEnumerable<OperationModel> GetAllOperations() => _context.Operations.AsAsyncEnumerable();
        public async Task AddOperation(OperationModel operation) => await _context.Operations.AddAsync(operation);
        public void UpdateOperation(OperationModel operation) => _context.Operations.Update(operation);
        public void UpdateOperations(List<OperationModel> operations) => _context.Operations.UpdateRange(operations);
        public void DeleteOperation(OperationModel operation) => _context.Operations.Remove(operation);
        public void DeleteOperations(List<OperationModel> operations) => _context.Operations.RemoveRange(operations);

    }
}
