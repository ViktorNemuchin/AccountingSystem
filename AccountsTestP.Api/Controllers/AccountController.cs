using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult<ResponseBaseDto>> GetAccountHistory(Guid accountId)
        {
            return await GetQuery(QueryAsync(new GetAccountHistoryQuery(accountId)).Result);
        }

        [HttpPost("top-up")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TopUpAccount([FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(account.AccountNumber, Convert.ToDecimal(account.CurrentAmount), true, account.ActualDateTime, account.AccountType, account.OperationId, account.Puprpose);
            return Ok(await CommandAsync(accountCommand));
        }

        [HttpPost("withdraw")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> WithDrawAccount([FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(account.AccountNumber, Convert.ToDecimal(account.CurrentAmount), false, account.ActualDateTime, account.AccountType, account.OperationId, account.Puprpose);
            return Ok(await CommandAsync(accountCommand));

        }
        [HttpPost("transfer")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TransferAccount([FromBody]AmountTransferDto account)
        {
            var accountCommand = new CreateTransferAccountCommand(account.SourceAccountNumber, account.DestinationAccountNumber, Convert.ToDecimal(account.CurrentAmount), account.ActualDateTime, account.SourceAccountType, account.DestinationAccountType, account.OperationId, account.Purpose);
            return Ok(await CommandAsync(accountCommand));

        }
    }
}