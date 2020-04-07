using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{

    public interface IOperationParameterRepository:IBaseRepository
    {
        public IAsyncEnumerable<OperationParameterModel> GetOperationParametersByOperationId(Guid operationId);
        public Task AddOperationParameter(OperationParameterModel operationParameter);
        public void UpdateOperationParameter(OperationParameterModel operationParameter);
        public void UpdateOperationParameters(List<OperationParameterModel> operationParameters);
        public void DeleteOperationParameter(OperationParameterModel operationParameter);
        public void DeleteOperationParameters(List<OperationParameterModel> operationParameters);
    }
}
