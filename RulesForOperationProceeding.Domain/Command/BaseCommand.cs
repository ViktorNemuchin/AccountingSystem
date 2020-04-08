using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Базовый класс команд
    /// </summary>
    /// <typeparam name="T">Возвращаемый тип</typeparam>
    public abstract class BaseCommand<T> : IRequest<T> where T : class
    {
    }
}
