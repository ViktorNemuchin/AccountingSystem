using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    public class AccountHistoryModel: BaseModel
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;

        public AccountHistoryModel( int accountId, decimal amount) 
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
