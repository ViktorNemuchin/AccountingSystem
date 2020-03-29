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
    public class UpdateRuleCommandHandler:IRequestHandler<UpdateRuleCommand, ResponseBaseDto>
    {
        private IOperationTypeRepository _operationTypeRepostiry;
        private IRuleRepository _ruleRepository;
        private BaseHelpers<TraansferResultDto> _baseHelper = new BaseHelpers<TraansferResultDto>();

        public UpdateRuleCommandHandler(IOperationTypeRepository operationTypeRepository, IRuleRepository ruleRepository) =>
            (_operationTypeRepostiry, _ruleRepository) = (operationTypeRepository, ruleRepository);
        public async Task<ResponseBaseDto> Handle(UpdateRuleCommand request, CancellationToken cancellationToken)
        {
            var operationType = _operationTypeRepostiry.GetOperationTypeById(request.OperationTypeId);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var rule = new RulesModel(request.RuleId, request.SourceAccount, request.DestinationAccount, request.Formula, request.Description, request.DateFrom, request.OperationTypeId);
            _ruleRepository.UpdateRule(rule);
            await _ruleRepository.SaveChangesAsync();

            var result = new TraansferResultDto()
            {
                Id = rule.Id,
                Name = rule.Description
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
