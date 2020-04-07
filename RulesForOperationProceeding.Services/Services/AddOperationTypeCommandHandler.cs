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
    /// Класс обработчик команды добавления типа операции
    /// </summary>
    public class AddOperationTypeCommandHandler : IRequestHandler<AddOperationTypeCommand, ResponseBaseDto>
    {
        /// <summary>
        /// Интерфейс методов для работы с таблицей типов операций
        /// </summary>
        private readonly IOperationTypeRepository _operationTypeRepository;
        
        /// <summary>
        /// Интерфейс методов для работы с таблицей параметров типа операций
        /// </summary>
        private readonly IOperationParameterRepositor _operationParameterRepository;

        /// <summary>
        /// Интерфейс методов для работы с таблицей правил 
        /// </summary>
        private readonly IRuleRepository _ruleRepository;

        /// <summary>
        /// Базовый класс вспомогательных методов
        /// </summary>
        private readonly BaseHelpers<OperationTypeForListDto> _baseHelper = new BaseHelpers<OperationTypeForListDto>();
        /// <summary>
        /// Конструктор класса обработчика команды добавления типа операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типов операций</param>
        /// <param name="parameterRepositor">Интерфейс методов для работы с таблицей параметров типа операций</param>
        /// <param name="ruleRepository">Интерфейс методов для работы с таблицей правил</param>
        public AddOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor parameterRepositor, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, parameterRepositor, ruleRepository);

        /// <summary>
        /// Обработчик команды добавления типа операции
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>ResponseOKDto<TransferResultDto> --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(AddOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = new OperationTypeModel(request.TypeName);
            
            await _operationTypeRepository.AddOperationType(operationType, cancellationToken);
            
            var rulesList = new List<RulesModel>();
            foreach(var entry in request.Rules) 
            {
                rulesList.Add(_baseHelper.ConvertOperationRuleDtoToModel(entry,operationType.Id, request.DateFrom));
            }

            var parameterList = new List<OperationParameterModel>();

            foreach(var entry in request.Parameters) 
            {
                parameterList.Add(_baseHelper.ConverParameterDtoToModel(entry, operationType.Id));
            }

            if (rulesList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Пожалуйста укажите хотя бы одно правило");
            if (parameterList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Пожалуйста укажите хотя бы один параметр");
            
            await _ruleRepository.AddRules(rulesList, cancellationToken);
            
            await _operationParameterRepository.AddOperationParameters(parameterList, cancellationToken);           

            await _operationTypeRepository.SaveChangesAsync();
            var result = new OperationTypeForListDto
            {
                OperationtypeId =operationType.Id,
                OperationTypeName = request.TypeName
            };


            return _baseHelper.FormOkResponse(result);
        }
    }
}
