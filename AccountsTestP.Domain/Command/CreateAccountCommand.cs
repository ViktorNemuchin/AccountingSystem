using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Command
{
    public class CreateAccountCommand : CommandBase<ResponseBaseDto>
    {
        public CreateAccountCommand(decimal initialBalance, int accountType, Guid documentId, int accountNumber)
        {
            InitialBalance = initialBalance;
            AccountNumber = accountNumber;
            AccountType = accountType;
            DocumentId = documentId;
            
        }

        public decimal InitialBalance { get; private set; }

        public int AccountNumber { get; set; }

        public int AccountType { get; private set; }

        public Guid DocumentId { get; private set; }

    }
}
