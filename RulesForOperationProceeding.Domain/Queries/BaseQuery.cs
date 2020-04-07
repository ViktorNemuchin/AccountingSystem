using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    /// <summary>
    /// Базовый класс запросов 
    /// </summary>
    /// <typeparam name="TResult">Тип класса результирующего объекта </typeparam>
    public abstract class BaseQuery<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
