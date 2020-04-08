using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertOperationToTransfer.Domain.Queries
{
    /// <summary>
    /// Класс базового запроса
    /// </summary>
    /// <typeparam name="TResult">Тип объекта выводимого результата</typeparam>
    public abstract class BaseQuery<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
