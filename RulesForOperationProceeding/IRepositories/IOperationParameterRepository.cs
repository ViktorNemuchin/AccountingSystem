using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    public interface IOperationParameterRepositor:IBaseRepository
    {
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersById(Guid operationyTypeId);
        public Task<OperationParameterModel> GetOperationParameter(Guid operationParameterId);
        public Task AddOperationParameter(OperationParameterModel operation);
        public Task AddOperationParameters(List<OperationParameterModel> operations);
        public void UpdateOperationParameter(OperationParameterModel operationParameter);
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters);
        public void DeleteOperationParameter(OperationParameterModel operationParameter); 
    }
}
