using MediatR;

namespace AccountsTestP.Domain.Queries
{
    /// <summary>
    /// Базовый абстрактный класс для всех запосов 
    /// </summary>
    /// <typeparam name="TResult">Тип DTO для результата текущего запроса</typeparam>
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
