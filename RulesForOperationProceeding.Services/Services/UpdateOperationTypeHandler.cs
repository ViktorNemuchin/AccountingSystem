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
    /// Класс обработчика команды на обновление типа операции 
    /// </summary>
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса обработчика команды на обновление типа операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типов операций</param>
        /// <param name="parameterRepositor">Интерфейс методов для работы с таблицей параметров типа операций</param>
        /// <param name="ruleRepository">Интерфейс методов для работы с таблицей правила типа операций</param>
        public UpdateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor parameterRepositor, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, parameterRepositor, ruleRepository);

        /// <summary>
        /// Обработчик команды на обновление типа операции
        /// </summary>
        /// <param name="request">Команда на обновление типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var rulesList = new List<RulesModel>();
            if (request.Rules.Count != 0) 
            {
                foreach (var entry in request.Rules)
                {
                    rulesList.Add(_baseHelper.ConvertOperationRuleDtoToModel(entry, request.OperationTypeId));
                }
                _ruleRepository.UpdateRules(rulesList);
            }

            var parameterList = new List<OperationParameterModel>();
            if (request.OperationParameters.Count != 0) 
            {
                foreach (var entry in request.OperationParameters)
                {
                    parameterList.Add(_baseHelper.ConverParameterDtoToModel(entry, request.OperationTypeId));
                }
                _operationParameterRepository.UpdateOperationParameters(parameterList);
            }
            var operationType = new OperationTypeModel(request.OperationTypeId, request.OperationTypeName);
            _operationTypeRepository.UpdateOperationType(operationType);
            await _operationTypeRepository.SaveChangesAsync();
            
            var result = new TransferResultDto()
            {
                Id = request.OperationTypeId,
                Name = request.OperationTypeName
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
