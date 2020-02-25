using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    public class BufferForFutureEntriesDatesModel:BaseModel
    {
        public Guid SourceAccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public Guid OperationId { get; private set; }
        public DateTimeOffset CreationDate { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset DueDate { get; private set; }
        public string Description { get; private set; }
       

        public BufferForFutureEntriesDatesModel(Guid sourceAccountId, Guid destinationAccountId, decimal amount, Guid operationId, DateTimeOffset dueDate, string description) 
        {
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            Amount = amount;
            OperationId = operationId;
            DueDate = dueDate;
            Description = description;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }


    }
}
