using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{accountId}/history")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ResponseBaseDto>> GetAccountHistory(int accountId) 
        {
            return await GetQuery(QueryAsync(new GetAccountHistoryQuery(accountId)).Result);
        }

        [HttpPost("{accountId}/top-up")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TopUpAccount([FromRoute]int accountId, [FromBody]AmountTransferDto account) 
        {
                var accountCommand = new CreateAccountHistoryEntryCommand(accountId, Convert.ToDecimal(account.CurrentAmount), true);
                return Ok(await CommandAsync(accountCommand));
        }

        [HttpPost("{accountId}/withdraw")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> WithDrawAccount([FromRoute]int accountId, [FromBody]AmountTransferDto account)
        {
                var accountCommand = new CreateAccountHistoryEntryCommand(accountId, Convert.ToDecimal(account.CurrentAmount), false);
                return Ok(await CommandAsync(accountCommand));

        }
        [HttpPost("{sourceAccountId}/transfer/{destinationAccountId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TransferAccount([FromRoute]int sourceAccountId, [FromRoute]int destinationAccountId,[FromBody]AmountTransferDto account)
        {
            var accountCommand = new CreateTransferAccountCommand(sourceAccountId, destinationAccountId,Convert.ToDecimal(account.CurrentAmount));
            return Ok(await CommandAsync(accountCommand));

        }
    }
}