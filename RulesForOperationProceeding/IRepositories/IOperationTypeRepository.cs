using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    public interface IOperationTypeRepository: IBaseRepository
    {
        public Task AddOperationType(OperationTypeModel operationType);
        public Task AddOperationTypeList(List<OperationTypeModel> operationTypes);
        public Task<OperationTypeModel> GetOperationTypeById(Guid operationTypeId);
        public Task<OperationTypeModel> GetOperationTypeByName(string operationName);
        public IAsyncEnumerable<OperationTypeModel> GetAllOperationtypes();
        public void UpdateOperationType(OperationTypeModel operationType);
        public void DeleteOperationType(OperationTypeModel operationType);
    }
}
