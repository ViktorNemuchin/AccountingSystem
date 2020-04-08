using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Services.Helpers;
using System.Threading.Tasks;
using System.Threading;

namespace RulesForOperationProceeding.Services.Services
{
    /// <summary>
    /// Класс обработчика запроса на получение списка правил для запроса типа операции по  Id типа операции
    /// </summary>
    public class GetRulesByOperationTypeIdQueryHandler : IRequestHandler<GetRulesForOperationTypeQueryByOperationId, List<RuleDto>>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<RuleDto> _baseHelper = new BaseHelpers<RuleDto>();

        /// <summary>
        /// Конструктор класса обработчика запроса на получение списка правил для запроса типа операции по  Id типа операции
        /// </summary>
        /// <param name="ruleRepository">Интерфейс методов работы с таблицей правил для операций</param>
        public GetRulesByOperationTypeIdQueryHandler(IRuleRepository ruleRepository) => (_ruleRepository) = (ruleRepository);

        /// <summary>
        /// Обработчика запроса на получение списка правил для запроса типа операции по  Id типа операции
        /// </summary>
        /// <param name="request">Запрос на получение списка правил для запроса типа операции по  Id типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>List<RuleDTO> --- Результат успешного выполнения запроса</returns>
        public async Task<List<RuleDto>> Handle(GetRulesForOperationTypeQueryByOperationId request, CancellationToken cancellationToken)
        {
            var rulesList = new List<RuleDto>();
            await foreach(var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId,cancellationToken)) 
            {
                var rule = _baseHelper.ConvertRuleModelToDTO(entry);
                rulesList.Add(rule);
            }

            return rulesList;
        }
    }
}
