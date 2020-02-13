using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator) 
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }

        protected async Task <ActionResult<T>> GetQuery<T>(T data)
        {
            return Ok(data);
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }

    }
}