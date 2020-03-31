using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Domain.Command;

namespace RulesForOperationProceeding.Api.Controllers
{
    [Route("api/accounting-system/operation-types")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RuleController(IMediator mediator) => (_mediator) = (mediator);
        #region HttpGet
        /// <summary>
        /// Получение правила учета операции по  идентификатору правила учета операции
        /// </summary>
        /// <param name="ruleId">Id правила</param>
        /// <response code="200">Возвращает правило учета операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id правила вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("{operationTypeId}/rules/{ruleId}")]
        [ProducesResponseType(typeof(ResponseOkDto<RuleDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]

        public async Task<IActionResult> GetRuleByRuleId(Guid ruleId)
            => Ok(await _mediator.Send(new GetRuleByRuleIdQuery(ruleId)));
        /// <summary>
        /// Получение списка правил операции для определенного типа операций 
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <response code="200">Возвращает список правил видов учета операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("{operationTypeId}/rules")]
        [ProducesResponseType(typeof(ResponseOkDto<List<RuleDto>>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> GetRulesByOperationId(Guid operationTypeId)
            => Ok(await _mediator.Send(new GetRulesByOperationTypeIdQuery(operationTypeId)));
        #endregion

        #region HttpPost
        /// <summary>
        /// Добавления правила к указанному типу операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <param name="rule">Правило для добавления</param>
        /// <response code="200">Возвращает статус Ok, id и название правила операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("{operationTypeId}/rules")]
        [ProducesResponseType(typeof(ResponseOkDto<TransferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]

        public async Task<IActionResult> AddRuleToOperationType(Guid operationTypeId, TransferRuleForRuleControllerDto rule)
            => Ok(await _mediator.Send(new AddRuleToOperationTypeIdCommand(rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description,rule.DateFrom, operationTypeId)));
        #endregion
        #region HttpPut
        /// <summary>
        /// Изменение правила для типа учета операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <param name="ruleId">Id  правила</param>
        /// <param name="rule">Данные для изменения правил</param>
        /// <response code="200">Возвращает статус Ok, id и название правила операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id правила и вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPut("{operationTypeId}/rules/{ruleId}")]
        public async Task<IActionResult> UpdateRule(Guid operationTypeId, Guid ruleId, TransferRuleForRuleControllerDto rule)
            => Ok(await _mediator.Send(new UpdateRuleCommand(ruleId, rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description,rule.DateFrom, operationTypeId)));
        #endregion
        #region HttpDelete
        /// <summary>
        /// Удаление правила операции по указанном идентификатору правила операции
        /// </summary>
        /// <param name="ruleId">Идентификатор правила операции</param>
        /// <response code="200">Возвращает статус Ok, id и название правила операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id правила операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpDelete("{operationTypeId}/rules/{ruleId}")]
        public async Task<IActionResult> DeleteRule(Guid ruleId)
            => Ok(await _mediator.Send(new DeleteRuleCommand(ruleId)));
        #endregion
    }
}