using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Models
{
    public class OperationTransferModel:BaseModel
    {
        public string SourceAcount { get; private set; }
        public string DestinationAccount { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public decimal Ammount { get; private set; } 
        public string Description { get; private set; }
        public Guid OperationTypeId { get; private set; }
        public bool IsRegistered { get; private set; }
    }
}
