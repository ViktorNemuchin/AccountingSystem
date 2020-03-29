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
    public class UpdateOperationParameterCommandHandler : IRequestHandler<UpdateOperationParameterCommand, ResponseBaseDto>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<TraansferResultDto> _baseHelper = new BaseHelpers<TraansferResultDto>();

        public UpdateOperationParameterCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository) => (_operationTypeRepository, _operationParameterRepository) = (operationTypeRepository, operationParameterRepository);
        public async Task<ResponseBaseDto> Handle(UpdateOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationTypeById(request.OperationTypeId);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Такой тип операции не найден");

            var operationParameter = new OperationParameterModel(request.OperationParameterId, request.OperationParameterName, request.OperationParameterValue, request.OperationTypeId);
            _operationParameterRepository.UpdateOperationParameter(operationParameter);
            await _operationParameterRepository.SaveChangesAsync();

            var result = new TraansferResultDto()
            {
                Id = operationParameter.Id,
                Name = operationParameter.OperationParameterName
            };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
