using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    public class AccountTypeModel:BaseModel
    {   
        public int AccountTypeNumber { get; private set; }
        public string AccountTypeName { get; private set; }

        public bool IsActive { get; private set; }

        public AccountTypeModel(int accountTypeNumber, string accountTypeName, bool isActive) 
        {
            AccountTypeNumber = accountTypeNumber;
            AccountTypeName = accountTypeName;
            IsActive = isActive;
        }
      

    }
}
