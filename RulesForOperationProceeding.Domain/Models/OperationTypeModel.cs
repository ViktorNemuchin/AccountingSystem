using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    public class OperationTypeModel: BaseModel
    {
        public string OperationTypeName { get; private set; }

        public OperationTypeModel(Guid id, string operationTypeName) => (Id, OperationTypeName) = (id, operationTypeName);
    }
}

