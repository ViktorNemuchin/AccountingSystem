using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Data.AccountDbContext
{
    public class AccountsGenerated
    {
        public AccountsGenerated() 
        { }
        public List<AccountModel> SeedAccounts() 
        {
            var accounts = new List<AccountModel>();

            accounts.Add(new AccountModel(56, "45345453dfvxv", 6000.56M));
            accounts.Add(new AccountModel(47, "456790-=dfskdf", 7000.67M));
            accounts.Add(new AccountModel(87, "9304823742350", 125000.78M));
            
            return accounts;
        }

    }
}
