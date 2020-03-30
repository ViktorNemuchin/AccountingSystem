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
    [Route("api/operation-types")]
    [ApiController]
    public class OperationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OperationTypeController(IMediator mediator) => (_mediator) = (mediator);

        #region HttpGet
        /// <summary>
        /// Получение списка видов учета операций
        /// </summary>
        /// <response code="200">Возвращает список видов учета операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        
        [HttpGet("")]
        [ProducesResponseType(typeof(ResponseOkDto<OperationTypeForListDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> GetAllOperationTypes() 
            => Ok(await _mediator.Send(new GetAllOperationTypes()));

        /// <summary>
        /// Запрос вида операции по Id вида учета операции 
        /// </summary>
        /// <param name="operationTypeId">Id вида операции</param>
        /// <response code="200">Возвращает вида операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе Id вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска типа учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("id/{operationTypeId}")]
        [ProducesResponseType(typeof(ResponseOkDto<OperationTypeDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> GetOperationTypeById(Guid operationTypeId)
            => Ok(await _mediator.Send(new GetOperationTypeByIdQuery(operationTypeId)));

        /// <summary>
        /// Запрос вида операции по названию вида операции
        /// </summary>
        /// <param name="operationTypeName">Название вида операции</param>
        /// <response code="200">Возвращает вида операции</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе данных названия вида операции</response>
        /// <response code="404">Введены неправильные данные для поиска типа учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpGet("name/{operationTypeName}")]
        [ProducesResponseType(typeof(ResponseOkDto<OperationTypeDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> GetOperationTypeByOperationName(string operationTypeName)
            => Ok(await _mediator.Send(new GetOperationTypeByOperationTypeNameQuery(operationTypeName)));
        #endregion


        #region HttpPost
        /// <summary>
        /// Добавление вида операции
        /// </summary>
        /// <param name="operationType">Вид операции для добавления</param>
        /// <response code="200">Возвращает статус Ok при добавлении</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе данных о виде операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(ResponseOkDto<TraansferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> CreateNewOperationType(CreateOperationTypeTransferDto operationType) 
            => Ok(await _mediator.Send(new AddOperationTypeCommand(operationType.OperationTypeName, 
                operationType.Rules, 
                operationType.Parametters, 
                operationType.DateFrom, 
                operationType.DueDate)));
        #endregion

        #region HttpPut
        /// <summary>
        /// Изменение вида учета_операции имеющий указанный идентификатор операции в сооответсвии с новыми данными указанными в теле запроса
        /// </summary>
        /// <param name="operationTypeId">Id операции</param>
        /// <param name="operationType">Новые данные вида учета опервции</param>
        /// <response code="200">Возвращает статус Ok при успешном обновлении</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе данных о виде операции</response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>
        [HttpPut("{operationTypeId}")]
        [ProducesResponseType(typeof(ResponseOkDto<TraansferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> UpdateOPerationType(Guid operationTypeId, UpdateOpertionTypeTransferDto operationType)
            => Ok(await _mediator.Send(new UpdateOperationTypeCommand(operationTypeId, 
                operationType.OperationTypeName,
                operationType.DateFrom,
                operationType.DueDate, 
                operationType.Parametters,
                operationType.Rules)));
        #endregion

        #region HttpDelete
        /// <summary>
        /// Удаление вида операции
        /// </summary>
        /// <param name="operationTypeId">Id вида операции для удаления </param>
        /// <response code="200">Возвращает статус Ok при удалении</response>
        /// <response code="400">Возвращает ошибку данных при неправильном вводе id операции </response>
        /// <response code="404">Введены неправильные данные для поиска вида учета операции </response>
        /// <response code ="500">Возвращает сообщение о внутренней ошибке</response>        
        
        [HttpDelete("{operationTypeId}")]
        [ProducesResponseType(typeof(ResponseOkDto<TraansferResultDto>), 200)]
        [ProducesResponseType(typeof(ResponseMessageDto), 400)]
        [ProducesResponseType(typeof(ResponseMessageDto), 404)]
        [ProducesResponseType(typeof(ResponseMessageDto), 500)]
        public async Task<IActionResult> DeleteOperationType(Guid operationTypeId)
             => Ok( await _mediator.Send(new DeleteOperationTypeCommand(operationTypeId)));
        #endregion

    }
}