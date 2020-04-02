using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    public interface IOperationRepository: IBaseRepository
    {
        public Task<OperationModel> GetOperationById(Guid operationId);
        public Task AddOperation(OperationModel operation);
        public void UpdateOperation(OperationModel operation);
        public void UpdateOperations(List<OperationModel> operations);
        public void DeleteOperation(OperationModel operation);
        public void DeleteOperations(List<OperationModel> operations);
    }
}
