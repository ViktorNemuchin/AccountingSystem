using System;

namespace AccountsTestP.Domain.Models
{
    public class AccountModel : BaseModel
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public int AccountType { get; private set; }
        public AccountModel(string accountNumber, decimal balance, int accountType)
        { 
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }
        public AccountModel(Guid id, string accountNumber, decimal balance, int accountType)
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }
    }
}
