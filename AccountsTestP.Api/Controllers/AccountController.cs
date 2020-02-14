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

        [HttpPost("{accountNumber}/top-up")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TopUpAccount([FromRoute]int accountNumber, [FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(accountNumber, Convert.ToDecimal(account.CurrentAmount), true, account.ActualDateTime, account.AccountType, account.DocumentId);
            return Ok(await CommandAsync(accountCommand));
        }

        [HttpPost("{accountNumber}/withdraw")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> WithDrawAccount([FromRoute]int accountNumber, [FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(accountNumber, Convert.ToDecimal(account.CurrentAmount), false, account.ActualDateTime, account.AccountType, account.DocumentId);
            return Ok(await CommandAsync(accountCommand));

        }
        [HttpPost("{sourceAccountNumber}/transfer/{destinationAccountNumber}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TransferAccount([FromRoute]int sourceAccountNumber, [FromRoute]int destinationAccountNumber, [FromBody]AmountTransferDto account)
        {
            var accountCommand = new CreateTransferAccountCommand(sourceAccountNumber, destinationAccountNumber, Convert.ToDecimal(account.CurrentAmount), account.ActualDateTime, account.SourceAccountType, account.DestinationAccountType, account.DocumentId);
            return Ok(await CommandAsync(accountCommand));

        }
    }
}