using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    public class AccountModel:BaseModel
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public AccountModel(int id, string accountNumber, decimal balance) 
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
