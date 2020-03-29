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
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<OperationTypeForListDto> _baseHelper = new BaseHelpers<OperationTypeForListDto>();
        
        public UpdateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor parameterRepositor, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, parameterRepositor, ruleRepository);

        public async Task<ResponseBaseDto> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var rulesList = new List<RulesModel>();
            if (request.Rules.Count != 0) 
            {
                foreach (var entry in request.Rules)
                {
                    rulesList.Add(_baseHelper.ConvertOperationRuleDtoToModel(entry, request.DateFrom));
                }
                _ruleRepository.UpdateRules(rulesList);
            }

            var parameterList = new List<OperationParameterModel>();
            if (request.OperationParameters.Count != 0) 
            {
                foreach (var entry in request.OperationParameters)
                {
                    parameterList.Add(_baseHelper.ConverParameterDtoToModel(entry));
                }
                _operationParameterRepository.UpdateOperationParameters(parameterList);
            }
            var operationType = new OperationTypeModel(request.OperationTypeId, request.OperationTypeName,request.DueDate);
            _operationTypeRepository.UpdateOperationType(operationType);
            await _operationTypeRepository.SaveChangesAsync();
            
            var result = new OperationTypeForListDto()
            {
                OperationtypeId = request.OperationTypeId,
                OperationTypeName = request.OperationTypeName
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
