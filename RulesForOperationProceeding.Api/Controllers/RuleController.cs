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
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RuleController(IMediator mediator) => (_mediator) = (mediator);
        #region HttpGet
        [HttpGet("{ruleId}")]
        public async Task<IActionResult> GetRuleByRuleId(Guid ruleId)
            => Ok(await _mediator.Send(new GetRuleByRuleIdQuery(ruleId)));

        [HttpGet("all/{operationId}")]
        public async Task<IActionResult> GetRulesByOperationId(Guid operationId)
            => Ok(await _mediator.Send(new GetRulesByOperationTypeIdQuery(operationId)));
        #endregion
        #region HttpPost
        [HttpPost("{operationTypeId}/add")]
        public async Task<IActionResult> AddRuleToOperationType(Guid operationTypeId, TransferRuleDto rule)
            => Ok(await _mediator.Send(new AddRuleToOperationTypeIdCommand(rule.SourceAccount, rule.DestinationAccount, rule.Formula, rule.Description, rule.DateFrom, operationTypeId)));
        #endregion
        #region HttpPut
        [HttpPut("{operationTypeId}/update/{ruleId}")]
        public async Task<IActionResult> UpdateRule(Guid operationTypeId, Guid ruleId, TransferRuleDto rule)
            => Ok(await _mediator.Send(new UpdateRuleCommand(ruleId, rule.SourceAccount, rule.DestinationAccount, rule.Formula, rule.Description, rule.DateFrom, operationTypeId)));
        #endregion
        #region HttpDelete
        [HttpDelete("{ruleId}/delete")]
        public async Task<IActionResult> DeleteRule(Guid ruleId)
            => Ok(await _mediator.Send(new DeleteRuleCommand(ruleId)));
        #endregion
    }
}