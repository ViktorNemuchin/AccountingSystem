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
    public class GetRulesByOperationTypeIdQueryHandler : IRequestHandler<GetRulesForOperationTypeQueryByOperationId, List<RuleDto>>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<RuleDto> _baseHelper = new BaseHelpers<RuleDto>();
        public GetRulesByOperationTypeIdQueryHandler(IRuleRepository ruleRepository) => (_ruleRepository) = (ruleRepository);
        public async Task<List<RuleDto>> Handle(GetRulesForOperationTypeQueryByOperationId request, CancellationToken cancellationToken)
        {
            var rulesList = new List<RuleDto>();
            await foreach(var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId)) 
            {
                var rule = _baseHelper.ConvertRuleModelToDTO(entry);
                rulesList.Add(rule);
            }

            return rulesList;
        }
    }
}
