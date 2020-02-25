using AccountsTestP.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountBalanceByDateQuery : QueryBase<ResponseBaseDto>
    {
        
        public GetAccountBalanceByDateQuery(Guid accountId, DateTimeOffset dateBy ) 
        {
            AccountId = accountId;
            DateBy = dateBy;
        }
        public Guid AccountId { get; private set; }
        public DateTimeOffset DateBy { get; private set; }


    }
}
