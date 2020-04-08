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
    /// Класс обработчика команды добавления правила к типу операции 
    /// </summary>
    public class AddRuleCommandHandler : IRequestHandler<AddRuleToOperationTypeIdCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepostiry;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса команды добавления правила к типу операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов работы с таблицей типов операций</param>
        /// <param name="ruleRepository">Интерфейс методов работы с таблицей типов операций</param>
        public AddRuleCommandHandler(IOperationTypeRepository operationTypeRepository, IRuleRepository ruleRepository) => 
            (_operationTypeRepostiry, _ruleRepository) = (operationTypeRepository, ruleRepository);

        /// <summary>
        /// Обработчика команды добавления правила к типу операции
        /// </summary>
        /// <param name="request">Команда добавления правила к типу операции </param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto<TransferResultDto> --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(AddRuleToOperationTypeIdCommand request, CancellationToken cancellationToken)
        {
            var operationType = _operationTypeRepostiry.GetOperationTypeById(request.OperationId, cancellationToken);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var rule = new RulesModel(request.SourceAccount, request.DestinationAccount,request.RuleOrderNumber, request.Formula, request.Description, request.DateFrom, request.OperationId);
            await _ruleRepository.AddRule(rule, cancellationToken);
            await _ruleRepository.SaveChangesAsync();

            var result = new TransferResultDto() 
            { 
                Id = rule.Id, 
                Name = rule.Description 
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
