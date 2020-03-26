using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.Repositories
{
    public class OperationTypeRepository: BaseRepository, IOperationTypeRepository
    {
        private readonly RulesForOperationProceedingDataDbContext _context;
        public OperationTypeRepository(RulesForOperationProceedingDataDbContext context)
            :base(context:context) 
        {
            _context = context; 
        }

        public async Task AddOperationType(OperationTypeModel operationType) => await _context.OperationTypes.AddAsync(operationType);
        public async Task AddOperationTypeList(List<OperationTypeModel> operationTypes) => await _context.OperationTypes.AddRangeAsync(operationTypes);
        public async Task<OperationTypeModel> GetOperationTypeById(Guid operationTypeId) => await _context.OperationTypes.Where(x => x.Id==operationTypeId).FirstOrDefaultAsync();
        public void UpdateOperationType(OperationTypeModel operationType) => _context.OperationTypes.Update(operationType);
        public void DeleteOperationType(OperationTypeModel operationType) => _context.OperationTypes.Remove(operationType);
        
    }
}
