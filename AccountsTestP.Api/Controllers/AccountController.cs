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


        /// <summary>
        /// Получить баланс счета по номеру счета и дате
        /// </summary>
        /// <param name="accountId">Id счета </param>
        /// <param name="date">Дата </param>
        /// <response code="200">Возвращает баланс счета</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id счета</response>
        /// <response code="404">Не найден счета по указзаному Id</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("{accountId}/balance")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ResponseBaseDto>> GetBalanceByDate(Guid accountId, [FromBody] ReportDateDto date)
        {
            return await GetQuery(QueryAsync(new GetAccountBalanceByDateQuery(accountId, date.Date)).Result);
        }
        /// <summary>
        /// Получить историю проводок по Id счета
        /// </summary>
        /// <param name="accountId">Id счета </param>
        /// <response code="200">Возвращает все записи проводок по указанному счету</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id счета</response>
        /// <response code="404">Не найден счета по указзаному Id</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("{accountId}/history")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ResponseBaseDto>> GetAccountHistory(Guid accountId)
        {
            return await GetQuery(QueryAsync(new GetAccountHistoryQuery(accountId)).Result);
        }

        /// <summary>
        /// Получить историю проводок по Id счета
        /// </summary>
        /// <param name="operationId">Id счета </param>
        /// <response code="200">Возвращает все записи проводок по указанному счету</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id счета</response>
        /// <response code="404">Не найден счета по указзаному Id</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("{operationId}/report")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ResponseBaseDto>> GetAccountHistoryForoperation(Guid operationId)
        {
            return await GetQuery(QueryAsync(new GetAccountHistoryForOperationQuery(operationId)).Result);
        }
        /// <summary>
        /// Операция пополнения счета. При отсутсвии счета в системе, создает новый счет и присваивает ему Id. 
        /// </summary>
        /// <param name="account">Сущность счета. Передается в теле запроса см. AmmountOneDto scheme <see cref="AmountOneDto"/></param>
        /// <response code="200">Возвращает текущий баланс и Id счета</response>
        /// <response code="400">Возвращает ошибку если введены неверные данные. При вводе отрицательной суммы сервис отвечает 400 ошибкой.</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("top-up")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TopUpAccount([FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(account.AccountNumber, Convert.ToDecimal(account.CurrentAmount), true, account.ActualDateTime, account.AccountType, account.OperationId, account.Comment);
            return Ok(await CommandAsync(accountCommand));
        }
        /// <summary>
        ///  Операция снятия со счета. При отсутсвии счета в системе, создает новый счет и присваивает ему Id, если ammount = 0.В противном случае возвращает ответ 200 со статусом error и сообщением об ошибке.
        /// </summary>
        /// <param name="account">Сущность счета. Передается в теле запроса см. AmmountOneDto scheme <see cref="AmountOneDto"/></param>
        /// <response code="200">Возвращает текущий баланс и Id счета или ошибку при недостаточном балансе на счете</response>
        /// <response code="400">Возвращает ошибку если введены неверные данные При вводе отрицательной суммы сервис отвечает 400 ошибкой.</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("withdraw")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> WithDrawAccount([FromBody]AmountOneDto account)
        {
            var accountCommand = new CreateAccountHistoryEntryCommand(account.AccountNumber, Convert.ToDecimal(account.CurrentAmount), false, account.ActualDateTime, account.AccountType, account.OperationId, account.Comment);
            return Ok(await CommandAsync(accountCommand));

        }
        /// <summary>
        ///  Операция перевода средств со счета на счет. При отсутсвии счета в системе, создает новый счет и присваивает ему Id, если ammount = 0.В противном случае возвращает ответ 200 со статусом error и сообщением об ошибке.
        /// </summary>
        /// <param name="account">Сущность счета. Передается в теле запроса см. AmmountTransferDto scheme<see cref="AmountTransferDto"/></param>
        /// <response code="200">Возвращает текущий баланс и Id счета или ошибку при недостаточном балансе на счете</response>
        /// <response code="400">Возвращает ошибку если введены неверные данные. При вводе отрицательной суммы сервис отвечает 400 ошибкой.</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("transfer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> TransferAccount([FromBody]AmountTransferDto account)
        {
            var accountCommand = new CreateTransferAccountCommand(account.SourceAccountNumber, account.DestinationAccountNumber, Convert.ToDecimal(account.CurrentAmount), account.ActualDateTime, account.SourceAccountType, account.DestinationAccountType, account.OperationId, account.Comment);
            return Ok(await CommandAsync(accountCommand));

        }
    }
}