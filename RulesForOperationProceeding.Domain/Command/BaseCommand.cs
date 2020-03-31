using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    public abstract class BaseCommand<T> : IRequest<T> where T : class
    {
    }
}
