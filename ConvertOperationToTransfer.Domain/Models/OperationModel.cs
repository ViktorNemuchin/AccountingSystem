using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    public class OperationModel: BaseModel
    {
        public Guid OperationTypeId { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public bool IsRegistered { get; private set; }
        public string OperationTypeName { get; private set; }

        public OperationModel(Guid id, string operationTypeName, bool isRegistered) => (Id, OperationTypeName, IsRegistered) = (id, operationTypeName, isRegistered);
        public OperationModel(string operationTypeName, bool isRegistered) => (OperationTypeName, IsRegistered) = (operationTypeName, isRegistered);

    }
}
