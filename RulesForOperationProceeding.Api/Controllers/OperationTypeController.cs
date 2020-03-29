using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Domain.Command;

namespace RulesForOperationProceeding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OperationTypeController(IMediator mediator) => (_mediator) = (mediator);

        #region HttpGet
 
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOperationTypes() 
            => Ok(await _mediator.Send(new GetAllOperationTypes()));
        

        [HttpGet("{operationTypeId}")]
        public async Task<IActionResult> GetOperationTypeById(Guid operationTypeId)
            => Ok(await _mediator.Send(new GetOperationTypeByIdQuery(operationTypeId)));


        [HttpGet("{operationTypeName}")]
        public async Task<IActionResult> GetOperationTypeByOperationName(string operationTypeName)
            => Ok(await _mediator.Send(new GetOperationTypeByOperationTypeNameQuery(operationTypeName)));
        #endregion


        #region HttpPost
        [HttpPost("add")]
        public async Task<IActionResult> CreateNewOperationType(CreateOpertionTypeTransferDto operationType) 
            => Ok(await _mediator.Send(new AddOperationTypeCommand(operationType.OperationTypeName, 
                operationType.Rules, 
                operationType.Parametters, 
                operationType.DateFrom, 
                operationType.DueDate)));
        #endregion
        #region HttpPut
        [HttpPut("{operationTypeId}/update")]
        public async Task<IActionResult> UpdateOPerationType(Guid operationTypeId, CreateOpertionTypeTransferDto operationType)
            => Ok(await _mediator.Send(new UpdateOperationTypeCommand(operationTypeId, 
                operationType.OperationTypeName,
                operationType.DateFrom,
                operationType.DueDate, 
                operationType.Parametters,
                operationType.Rules)));
        #endregion
        #region HttpDelete
        [HttpDelete("{operationTypeId}/delete")]
        public async Task<IActionResult> DeleteOperationType(Guid operationTypeId)
             => Ok( await _mediator.Send(new DeleteOperationTypeCommand(operationTypeId)));
        #endregion

    }
}