using ConvertOperationToTransfer.Data.ConvertOperationsDbContext;
using ConvertOperationToTransfer.Data.IRepository;
using ConvertOperationToTransfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.Repository
{
    public class OperationParameterRepository:BaseRepository, IOperationParameterRepository
    {
        public OperationParameterRepository(ConvertOperationToTransferDbContext context)
           : base(context: context)
        { }

        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersByOperationId(Guid operationId) => _context.OperationParameters.AsNoTracking().Where(x => x.Id == operationId).AsAsyncEnumerable();
        public async Task AddOperationParameter(OperationParameterModel operationParameter) => await _context.OperationParameters.AddAsync(operationParameter);
        public void UpdateOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Update(operationParameter);
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters) => _context.OperationParameters.UpdateRange(operationParameters);
        public void DeleteOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Remove(operationParameter);
        public void DeleteOperationParameters(List<OperationParameterModel> operationParameters) => _context.OperationParameters.RemoveRange(operationParameters);
    }
}
