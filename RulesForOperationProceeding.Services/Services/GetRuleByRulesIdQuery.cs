using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Services.Helpers;

namespace RulesForOperationProceeding.Services.Services
{
    /// <summary>
    /// Класс обработчика запроса на правило для типа операции по его Id
    /// </summary>
    public class GetRuleByRulesIdQueryHandler:IRequestHandler<GetRuleByRuleIdQuery,ResponseBaseDto>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<RuleDto> _baseHelper = new BaseHelpers<RuleDto>();

        /// <summary>
        /// Конструктор класса обработчика запроса на правило для типа операциипо его Id
        /// </summary>
        /// <param name="ruleRepository">Интерфейс методов работы с таблицей правил для операций</param>
        public GetRuleByRulesIdQueryHandler(IRuleRepository ruleRepository) => (_ruleRepository) = (ruleRepository);

        /// <summary>
        /// Обработчика запроса на правило для типа операциипо по его Id
        /// </summary>
        /// <param name="request">Запрос на правило для типа операции по его Id</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetRuleByRuleIdQuery request, CancellationToken cancellationToken)
        {
            var rule = await _ruleRepository.GetRuleEntry(request.RuleId, cancellationToken);
            if (rule == null)
                return _baseHelper.FormMessageResponse("Error", "Нет такого правила");
            var ruleDto = _baseHelper.ConvertRuleModelToDTO(rule);
            return _baseHelper.FormOkResponse(ruleDto);
        }
    }
}
