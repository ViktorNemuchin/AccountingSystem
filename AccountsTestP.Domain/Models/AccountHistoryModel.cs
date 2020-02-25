using System;

namespace AccountsTestP.Domain.Models
{
    public class AccountHistoryModel : BaseModel
    {
        public Guid SourceAccountId { get; private set; }
        public Guid DestinationAccountId { get; private set; }
        public decimal SourceAccountBalance { get; private set; }
        public decimal DestinationAccountBalance { get; private set; }
        public decimal Amount { get; private set; }
        public Guid OperationId { get; private set; }
        public DateTimeOffset CreationDate { get; private set; } 
        public DateTimeOffset DueDate { get; private set; }
        public string Description { get; private set; }

        public AccountHistoryModel(Guid destinationAccountId, Guid sourceAccountId, decimal amount, decimal sourceAccountBalance, decimal destinationAccountBalance, DateTimeOffset dueDate, string description, Guid operationId)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            SourceAccountBalance = sourceAccountBalance;
            DestinationAccountBalance = destinationAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }

        public AccountHistoryModel(Guid sourceAccountId, decimal amount, decimal sourceAccountBalance, DateTimeOffset dueDate, string description, Guid operationId)
        {
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            SourceAccountBalance = sourceAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }

        public AccountHistoryModel(Guid sourceAccountId, Guid destinationAccountId, decimal amount, decimal destinationAccountBalance, DateTimeOffset dueDate,  Guid operationId, string description)
        {
            DestinationAccountId = destinationAccountId;
            SourceAccountId = sourceAccountId;
            Amount = amount;
            DueDate = dueDate;
            Description = description;
            OperationId = operationId;
            DestinationAccountBalance = destinationAccountBalance;
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3));
        }
    }
}
