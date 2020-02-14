using System;

namespace AccountsTestP.Domain.Models
{
    public class AccountModel : BaseModel
    {
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public Guid DocumentId { get; private set; }
        public int AccountType { get; private set; }
        public AccountModel(int accountNumber, decimal balance, Guid documentId, int accountType)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            DocumentId = documentId;
            AccountType = accountType;
        }
    }
}
