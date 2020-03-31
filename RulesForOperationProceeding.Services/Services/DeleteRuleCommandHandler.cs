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
    public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, ResponseBaseDto>
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();
        public DeleteRuleCommandHandler(IRuleRepository ruleRepository) => (_ruleRepository) = (ruleRepository);
        public async Task<ResponseBaseDto> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
        {
            var rule = await _ruleRepository.GetRuleEntry(request.RuleId);
            if (rule == null)
                return _baseHelper.FormMessageResponse("Error", "Данное правило не найдено");
            _ruleRepository.DeleteRule(rule);
            await _ruleRepository.SaveChangesAsync();
            var result = new TransferResultDto() { Id = rule.Id, Name = rule.Description };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
