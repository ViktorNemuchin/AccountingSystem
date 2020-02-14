using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Queries
{
    public class GetAccountHistoryQuery : QueryBase<ResponseBaseDto>
    {
        public GetAccountHistoryQuery() { }
        public GetAccountHistoryQuery(Guid accountId)
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; set; }
    }
}
