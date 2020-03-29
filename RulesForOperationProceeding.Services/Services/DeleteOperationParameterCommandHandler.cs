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
    public class DeleteOperationParameterCommandHandler : IRequestHandler<DeleteOperationParameterCommand, ResponseBaseDto>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<TraansferResultDto> _baseHelper = new BaseHelpers<TraansferResultDto>();
        public DeleteOperationParameterCommandHandler(IOperationParameterRepositor operationParameterRepository) => (_operationParameterRepository) = (operationParameterRepository);
        public async Task<ResponseBaseDto> Handle(DeleteOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operationParameter = await _operationParameterRepository.GetOperationParameter(request.OperationParameterId);
            if (operationParameter == null)
                return _baseHelper.FormMessageResponse("Error", "Данное правило не найдено");
            _operationParameterRepository.DeleteOperationParameter(operationParameter);
            await _operationParameterRepository.SaveChangesAsync();
            var result = new TraansferResultDto() { Id = operationParameter.Id, Name = operationParameter.OperationParameterName };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
