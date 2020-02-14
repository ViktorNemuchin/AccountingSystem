using System;

namespace AccountsTestP.Domain.Models
{
    public class AccountHistoryModel : BaseModel
    {
        public Guid SourceAccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime ChangedAt { get; private set; } = DateTime.Now;
        public DateTime ActualDate { get; private set; }

        public AccountHistoryModel(Guid destinationAccountId, Guid sourceAccountId, decimal amount, DateTime actualDate)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            ActualDate = actualDate;
        }

        public AccountHistoryModel(Guid sourceAccountId, decimal amount, DateTime actualDate)
        {
            SourceAccountId = sourceAccountId;
            Amount = amount;
            ActualDate = actualDate;
        }
    }
}
