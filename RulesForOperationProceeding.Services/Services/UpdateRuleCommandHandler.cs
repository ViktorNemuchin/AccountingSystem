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
    /// Класс обработчика команды изменения правила для типа операции   
    /// </summary>
    public class UpdateRuleCommandHandler:IRequestHandler<UpdateRuleCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepostiry;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса обработчика команды изменения правила для типа операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типов операций</param>
        /// <param name="ruleRepository">Интерфейс методов для работы с таблицей правил для типа операций</param>
        public UpdateRuleCommandHandler(IOperationTypeRepository operationTypeRepository, IRuleRepository ruleRepository) =>
            (_operationTypeRepostiry, _ruleRepository) = (operationTypeRepository, ruleRepository);

        /// <summary>
        /// Обработчик команды изменения правил для типа операции
        /// </summary>
        /// <param name="request">Команда изменения правила для типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(UpdateRuleCommand request, CancellationToken cancellationToken)
        {
            var operationType = _operationTypeRepostiry.GetOperationTypeById(request.OperationTypeId, cancellationToken);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var rule = new RulesModel(request.RuleId, request.SourceAccount, request.DestinationAccount,request.RuleOrderNumber, request.Formula, request.Description, request.DateFrom, request.OperationTypeId);
            _ruleRepository.UpdateRule(rule);
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
