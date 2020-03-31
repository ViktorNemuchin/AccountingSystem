using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Command;

namespace RulesForOperationProceeding.Api.Controllers
{
    [Route("api/accounting-system/operation-types/")]
    [ApiController]
    public class OperationParameterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OperationParameterController(IMediator mediator) => (_mediator) = (mediator);
        #region HttpGet
        /// <summary>
        /// Получение всех параметров для типа операции по Id типа операции
        /// </summary>
        /// <param name="operationTypeId"> Id типа операции</param>
        /// <response code="200">Возвращает список правил</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id типа опреации</response>
        /// <response code="404">Не найдены параметры по Id типа операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        

        [HttpGet("{operationTypeId}/operation-parameters")]
        [ProducesResponseType(typeof(ResponseOkDto<List<OperationParameterDto>>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> GetOperationParameterByOperationTypeId(Guid operationTypeId)
            => Ok(await _mediator.Send(new GetParametersForOperationByOperationIdQuery(operationTypeId)));
        #endregion
        #region HttpPost
        /// <summary>
        /// Добавление параметра к списку параметров для типа операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <param name="operationParameter">Параметр операции для добавления</param>
        /// <response code="200">Возвращает статус OK, Id и название параметра</response>
        /// <response code="400">Тип предоставленных данных не совподает с Guid</response>
        /// <response code="404">Нет доступных данных</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("{operationTypeId}/operation-parameters")]
        [ProducesResponseType(typeof(ResponseOkDto<TransferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> AddParameterToOperationType(Guid operationTypeId, TransferOperationParameterDto operationParameter)
             => Ok(await _mediator.Send(new AddOperationParameterCommand(operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId)));
        #endregion
        #region HttpPut
        /// <summary>
        /// Изменение данных параметра типа операции по Id параметра операции
        /// </summary>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <param name="operationParameterId">Id параметра операции</param>
        /// <param name="operationParameter">Данные для измененияя прарметра операции</param>
        /// <response code="200">Возвращает статус OK, Id и название параметра</response>
        /// <response code="400">Тип предоставленных данных не совподает с тркебуемым</response>
        /// <response code="404">Нет доступных данных</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
       
        [HttpPut("{operationTypeId}/operation-parameters/{operationParameterId}")]
        [ProducesResponseType(typeof(ResponseOkDto<TransferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> UpdateOperationParameter(Guid operationTypeId,Guid operationParameterId, TransferOperationParameterDto operationParameter)
            => Ok(await _mediator.Send(new UpdateOperationParameterCommand(operationParameterId, operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId)));
        #endregion
        #region HttpDelete
        /// <summary>
        /// Удаление параметра операции по Id параметра операции
        /// </summary>
        /// <param name="operationParameterId">Id параметра операции</param>
        /// <response code="200">Возвращает статус OK, Id и название параметра</response>
        /// <response code="400">Тип предоставленных данных не совподает с тркебуемым</response>
        /// <response code="404">Нет доступных данных</response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpDelete("{operationTypeId}/operation-parameters/{operationParameterId}")]
        [ProducesResponseType(typeof(ResponseOkDto<TransferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> DeleteOperationParameter(Guid operationParameterId)
            => Ok(await _mediator.Send(new DeleteOperationParameterCommand(operationParameterId)));
        #endregion

    }
}