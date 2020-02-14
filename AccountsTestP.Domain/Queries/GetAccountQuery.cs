using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountQuery : QueryBase<AccountDto>
    {
        GetAccountQuery() { }
        public GetAccountQuery(int accountNumber)
        {
            AccountNumber = accountNumber;
        }
        public int AccountNumber { get; set; }
    }
}
