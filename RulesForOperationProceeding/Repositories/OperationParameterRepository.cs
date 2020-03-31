using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesForOperationProceeding.Data.IRepositories;

namespace RulesForOperationProceeding.Data.Repositories
{
    public class OperationParameterRepository:BaseRepository, IOperationParameterRepositor
    {
 
        public OperationParameterRepository(RulesForOperationProceedingDataDbContext context)
            : base(context: context)
        {
        }
        public async Task AddOperationParameter(OperationParameterModel operation) =>  await _context.OperationParameters.AddAsync(operation);
        public async Task AddOperationParameters (List<OperationParameterModel> operations) => await _context.OperationParameters.AddRangeAsync(operations);
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersById(Guid operationyTypeId) => _context.OperationParameters.AsNoTracking().Where(x => x.OperationTypeId == operationyTypeId).AsAsyncEnumerable();
        public async Task<OperationParameterModel> GetOperationParameter(Guid operationParameterId) => await _context.OperationParameters.AsNoTracking().Where(x => x.Id == operationParameterId).FirstOrDefaultAsync();
        public void UpdateOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Update(operationParameter);
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters) => _context.OperationParameters.UpdateRange(operationParameters);
        public void DeleteOperationParameter(OperationParameterModel operationParameter) => _context.OperationParameters.Remove(operationParameter);
    }
}
