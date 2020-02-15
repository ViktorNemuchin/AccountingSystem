using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountQuery : QueryBase<AccountDto>
    {
        GetAccountQuery() { }
        public GetAccountQuery(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        public string AccountNumber { get; set; }
    }
}
