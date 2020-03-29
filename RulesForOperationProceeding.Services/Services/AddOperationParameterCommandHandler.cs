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
    public class AddOperationParameterCommandHandler : IRequestHandler<AddOperationParameterCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepostiry;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<TraansferResultDto> _baseHelper = new BaseHelpers<TraansferResultDto>();

        public AddOperationParameterCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository) =>
            (_operationParameterRepository, _operationTypeRepostiry) = (operationParameterRepository, operationTypeRepository);
        public async Task<ResponseBaseDto> Handle(AddOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operation = await _operationTypeRepostiry.GetOperationTypeById(request.OperationTypeId);
            if (operation == null)
                return _baseHelper.FormMessageResponse("Error", "Тип операции не найден");

            var operationParameter = new OperationParameterModel(request.OperationParameterName, request.OperationParameterValue, request.OperationTypeId);
            await _operationParameterRepository.AddOperationParameter(operationParameter);
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
