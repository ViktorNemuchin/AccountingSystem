using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    public class OperationParameterModel: BaseModel
    {
        public string OperationParameterName { get; private set; }
        public string OperationParameterValue { get; private set; }
        public Guid OperationTypeId { get; private set; }

        public OperationParameterModel(Guid id, string operationParameterName, string operationParameterValue, Guid operationTypeId) =>
            (Id, OperationParameterName, OperationParameterValue, OperationTypeId) = (id, operationParameterName, operationParameterValue, operationTypeId);
        public OperationParameterModel(string operationParameterName, string operationParameterValue, Guid operationTypeId) =>
            (OperationParameterName, OperationParameterValue, OperationTypeId) = (operationParameterName, operationParameterValue, operationTypeId);
    }
}
