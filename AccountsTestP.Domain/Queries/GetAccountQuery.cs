using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountQuery: QueryBase<AccountDto>
    {
        GetAccountQuery() { }
        public GetAccountQuery(int accountId) 
        {
            AccountId = accountId;
        }
        public int AccountId { get; set; }
    }
}
