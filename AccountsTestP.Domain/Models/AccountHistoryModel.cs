using System;

namespace AccountsTestP.Domain.Models
{
    public class AccountHistoryModel : BaseModel
    {
        public Guid SourceAccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public Guid OperationId { get; private set; }
        public DateTime ChangedAt { get; private set; } = DateTime.Now;
        public DateTime ActualDate { get; private set; }
        public int Purpose { get; private set; }

        public AccountHistoryModel(Guid destinationAccountId, Guid sourceAccountId, decimal amount, DateTime actualDate, int purpose, Guid operationId)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            ActualDate = actualDate;
            Purpose = purpose;
            OperationId = operationId;
        }

        public AccountHistoryModel(Guid sourceAccountId, decimal amount, DateTime actualDate, int purpose, Guid operationId)
        {
            SourceAccountId = sourceAccountId;
            Amount = amount;
            ActualDate = actualDate;
            Purpose = purpose;
            OperationId = operationId;
        }
    }
}
