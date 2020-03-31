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
    public class AddRuleCommandHandler : IRequestHandler<AddRuleToOperationTypeIdCommand, ResponseBaseDto>
    {
        private IOperationTypeRepository _operationTypeRepostiry;
        private IRuleRepository _ruleRepository;
        private BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        public AddRuleCommandHandler(IOperationTypeRepository operationTypeRepository, IRuleRepository ruleRepository) => 
            (_operationTypeRepostiry, _ruleRepository) = (operationTypeRepository, ruleRepository);
        public async Task<ResponseBaseDto> Handle(AddRuleToOperationTypeIdCommand request, CancellationToken cancellationToken)
        {
            var operationType = _operationTypeRepostiry.GetOperationTypeById(request.OperationId);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var rule = new RulesModel(request.SourceAccount, request.DestinationAccount,request.RuleOrderNumber, request.Formula, request.Description, request.DateFrom, request.OperationId);
            await _ruleRepository.AddRule(rule);
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
