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
    public class DeleteOperationTypeCommandHandler : IRequestHandler<DeleteOperationTypeCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<OperationTypeForListDto> _baseHelper = new BaseHelpers<OperationTypeForListDto>();


        public DeleteOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, operationParameterRepository, ruleRepository);
        public async Task<ResponseBaseDto> Handle(DeleteOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationTypeById(request.OperationTypeId);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Данный тип операции не найден");
            
            await foreach(var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId))
                _operationParameterRepository.DeleteOperationParameter(entry);
            

            await foreach(var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId)) 
                _ruleRepository.DeleteRule(entry);

            _operationTypeRepository.DeleteOperationType(operationType);

            await _operationTypeRepository.SaveChangesAsync();

            var result = new OperationTypeForListDto() { OperationTypeName = operationType.OperationTypeName};

            return _baseHelper.FormOkResponse(result);
        }
    }
}
