using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public abstract class BaseQuery<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
