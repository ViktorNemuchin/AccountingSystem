using System;
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
    /// Класс обработчика команды добавления параметров к типу операции  
    /// </summary>
    public class AddOperationParameterCommandHandler : IRequestHandler<AddOperationParameterCommand, ResponseBaseDto>
    {
        /// <summary>
        /// Экземпляр интерфейс методов для работы таблицей типа операции
        /// </summary>
        private readonly IOperationTypeRepository _operationTypeRepostiry;

        /// <summary>
        /// Экземпляр интерфейса методов для работы с таблицей параметров операции.
        /// </summary>
        private readonly IOperationParameterRepositor _operationParameterRepository;

        /// <summary>
        /// Экземпляр базовых вспомогательных методов
        /// </summary>
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Класс обработчика команды добавления праметров к типу операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типа операции </param>
        /// <param name="operationParameterRepository">Интерфейс методов для работы с таблицей параметров типа операции</param>
        public AddOperationParameterCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository) =>
            (_operationParameterRepository, _operationTypeRepostiry) = (operationParameterRepository, operationTypeRepository);
        /// <summary>
        /// Обработчика команды добавления параметров к типу операции
        /// </summary>
        /// <param name="request">Команда добавления параметров к типу операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto<TransferResultDto> --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(AddOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operation = await _operationTypeRepostiry.GetOperationTypeById(request.OperationTypeId, cancellationToken);
            if (operation == null)
                return _baseHelper.FormMessageResponse("Error", "Тип операции не найден");

            var operationParameter = new OperationParameterModel(request.OperationParameterName, request.OperationParameterValue, request.OperationTypeId);
            await _operationParameterRepository.AddOperationParameter(operationParameter,cancellationToken);
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
