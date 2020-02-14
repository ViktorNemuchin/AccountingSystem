using MediatR;

namespace AccountsTestP.Domain.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
