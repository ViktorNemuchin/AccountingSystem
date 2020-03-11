using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AccountsTestP.Api.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] 
   public class BaseController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        /// <summary>
        /// Конструктор базоввого контроллера
        /// </summary>
        /// <param name="mediator">Объект класса MediatR</param>
        public BaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// Вызоав ассинхронного залания 
        /// </summary>
        /// <typeparam name="TResult">Результат объекта</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }
        /// <summary>
        /// Вызов запроса 
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="data">Параметры запросы </param>
        /// <returns></returns>
        protected async Task<ActionResult<T>> GetQuery<T>(T data)
        {
            return Ok(data);
        }
        /// <summary>
        /// Вызов команды 
        /// </summary>
        /// <typeparam name="TResult">Тип входящего результата</typeparam>
        /// <param name="command">Параметры команды</param>
        /// <returns></returns>
        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }

    }
}