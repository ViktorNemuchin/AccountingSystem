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
    public class AddOperationTypeCommandHandler : IRequestHandler<AddOperationTypeCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<OperationTypeForListDto> _baseHelper = new BaseHelpers<OperationTypeForListDto>();

        public AddOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor parameterRepositor, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, parameterRepositor, ruleRepository);
        public async Task<ResponseBaseDto> Handle(AddOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = new OperationTypeModel(request.TypeName, request.DueDate);
            
            await _operationTypeRepository.AddOperationType(operationType);
            
            var rulesList = new List<RulesModel>();
            foreach(var entry in request.Rules) 
            {
                rulesList.Add(_baseHelper.ConvertOperationRuleDtoToModel(entry,operationType.Id, request.DueDate));
            }

            var parameterList = new List<OperationParameterModel>();

            foreach(var entry in request.Parameters) 
            {
                parameterList.Add(_baseHelper.ConverParameterDtoToModel(entry, operationType.Id));
            }

            if (rulesList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Пожалуйста укажите хотя бы одно правило");
            if (parameterList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Пожалуйста укажите хотя бы один параметр");
            
            await _ruleRepository.AddRules(rulesList);
            
            await _operationParameterRepository.AddOperationParameters(parameterList);           

            await _operationTypeRepository.SaveChangesAsync();
            var result = new OperationTypeForListDto
            {
                OperationtypeId =operationType.Id,
                OperationTypeName = request.TypeName
            };


            return _baseHelper.FormOkResponse(result);
        }
    }
}
