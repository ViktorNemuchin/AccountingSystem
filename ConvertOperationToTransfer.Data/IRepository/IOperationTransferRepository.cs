using ConvertOperationToTransfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConvertOperationToTransfer.Data.IRepository
{
    public interface IOperationTransferRepository: IBaseRepository
    {
        public IAsyncEnumerable<OperationTransferModel> GetTransfersByOerationId(Guid operationId);
        public IAsyncEnumerable<OperationTransferModel> GetTransferForOperationReistry(Guid operationId, bool isRegistered);
        public Task AddTransfer(OperationTransferModel transfer);
        public void UpdateOperation(OperationTransferModel transfer);
        public void UpdateOperations(List<OperationTransferModel> transfers);
        public void DeleteOperation(OperationTransferModel transfer);
        public void DeleteOperations(List<OperationTransferModel> transfers);
    }
}
