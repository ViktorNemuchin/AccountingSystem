using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Command
{
    public class CreateAccountCommand : CommandBase<ResponseBaseDto>
    {
        public CreateAccountCommand(decimal initialBalance, int accountType, Guid operationId, string accountNumber)
        {
            InitialBalance = initialBalance;
            AccountNumber = accountNumber;
            AccountType = accountType;
            OperationId = operationId;
        }

        public decimal InitialBalance { get; private set; }

        public string AccountNumber { get; set; }

        public int AccountType { get; private set; }

        public Guid OperationId { get; private set; }

    }
}
