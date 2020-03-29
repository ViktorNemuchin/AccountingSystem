using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Models
{
    public class OperationTypeModel: BaseModel
    {
        public string OperationTypeName { get; private set; }
        public DateTimeOffset DueDate { get; private set; }

        public OperationTypeModel(Guid id, string operationTypeName, DateTimeOffset dueDate) => (Id, OperationTypeName, DueDate) = (id, operationTypeName, dueDate);
        public OperationTypeModel(string operationTypeName, DateTimeOffset dueDate) => (OperationTypeName, DueDate) = (operationTypeName, dueDate);
    }
}

