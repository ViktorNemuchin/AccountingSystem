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
    /// Класс обработчика запроса на получение списка правил для типа операции по  Id типа операции
    /// </summary>
    public class GetRulesByTypeIdQueryHandler : IRequestHandler<GetRulesByOperationTypeIdQuery, ResponseBaseDto>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<List<RuleDto>> _baseHelpers = new BaseHelpers<List<RuleDto>>();

        /// <summary>
        /// Конструктор класса обработчика запроса на получение списка правил для запроса типа операции по  Id типа операции
        /// </summary>
        /// <param name="ruleRepository">Интерфейс методов работы с таблицей правил для операций</param>
        public GetRulesByTypeIdQueryHandler(IRuleRepository ruleRepository) =>
            (_ruleRepository) = (ruleRepository);

        /// <summary>
        /// Обработчик запроса на получение списка правил для запроса типа операции по  Id типа операции
        /// </summary>
        /// <param name="request">Запроса на получение списка правил для запроса типа операции по  Id типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetRulesByOperationTypeIdQuery request, CancellationToken cancellationToken)
        {
            var ruleList = new List<RuleDto>();
            await foreach (var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId, cancellationToken)) 
            {
                ruleList.Add(_baseHelpers.ConvertRuleModelToDTO(entry));
            }
            if (ruleList.Count == 0)
                return _baseHelpers.FormMessageResponse("Error", "нет доступных правил");

            return _baseHelpers.FormOkResponse(ruleList);
        }
    }
}
