﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RulesForOperationProceeding.Domain.Command;
using RulesForOperationProceeding.Services.Helpers;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Domain.DTOS;
using System.Threading.Tasks;
using System.Threading;
using RulesForOperationProceeding.Domain.Models;

namespace RulesForOperationProceeding.Services.Services
{
    /// <summary>
    /// Класс обработчика команды на обновление параметра типа операции 
    /// </summary>
    public class UpdateOperationParameterCommandHandler : IRequestHandler<UpdateOperationParameterCommand, ResponseBaseDto>
    {

        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса обработчика команды на обновление параметра типа операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типов операций</param>
        /// <param name="operationParameterRepository">Интерфейс методов для работы с таблицей параметров типов операций<</param>
        public UpdateOperationParameterCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository) => (_operationTypeRepository, _operationParameterRepository) = (operationTypeRepository, operationParameterRepository);
        /// <summary>
        /// Обработчик команды на обновление параметра типа операции
        /// </summary>
        /// <param name="request">Команда на обновление параметров </param>
        /// <param name="cancellationToken">ТОкен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(UpdateOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationTypeById(request.OperationTypeId, cancellationToken);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var operationParameter = new OperationParameterModel(request.OperationParameterId, request.OperationParameterName, request.OperationParameterValue, request.OperationTypeId);
            _operationParameterRepository.UpdateOperationParameter(operationParameter);
            await _operationParameterRepository.SaveChangesAsync();

            var result = new TransferResultDto()
            {
                Id = operationParameter.Id,
                Name = operationParameter.OperationParameterName
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
