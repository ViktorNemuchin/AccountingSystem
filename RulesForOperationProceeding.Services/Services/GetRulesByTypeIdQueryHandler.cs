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
    public class GetRulesByTypeIdQueryHandler : IRequestHandler<GetRulesByOperationTypeIdQuery, ResponseBaseDto>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<List<RuleDto>> _baseHelpers = new BaseHelpers<List<RuleDto>>();
        public async Task<ResponseBaseDto> Handle(GetRulesByOperationTypeIdQuery request, CancellationToken cancellationToken)
        {
            var ruleList = new List<RuleDto>();
            await foreach (var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId)) 
            {
                ruleList.Add(_baseHelpers.ConvertRuleModelToDTO(entry));
            }
            if (ruleList.Count == 0)
                return _baseHelpers.FormMessageResponse("Error", "нет доступных правил");

            return _baseHelpers.FormOkResponse(ruleList);
        }
    }
}
