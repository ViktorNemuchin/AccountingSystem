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
    public class GetRuleByRulesIdQueryHandler:IRequestHandler<GetRuleByRuleIdQuery,ResponseBaseDto>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<RuleDto> _baseHelper = new BaseHelpers<RuleDto>();
        public GetRuleByRulesIdQueryHandler(IRuleRepository ruleRepository) => (_ruleRepository) = (ruleRepository);

        public async Task<ResponseBaseDto> Handle(GetRuleByRuleIdQuery request, CancellationToken cancellationToken)
        {
            var rule = await _ruleRepository.GetRuleEntry(request.RuleId);
            if (rule == null)
                return _baseHelper.FormMessageResponse("Error", "Нет такого правила");
            var ruleDto = _baseHelper.ConvertRuleModelToDTO(rule);
            return _baseHelper.FormOkResponse(ruleDto);
        }
    }
}
