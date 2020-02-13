using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountHistoryQuery: QueryBase<ResponseBaseDto>
    {
        public GetAccountHistoryQuery() { }
        public GetAccountHistoryQuery(int accountId) 
        {
            AccountId = accountId;
        }

        public int AccountId { get; set; }
    }
}
