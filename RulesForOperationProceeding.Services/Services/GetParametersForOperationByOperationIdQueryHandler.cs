using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace RulesForOperationProceeding.Services.Services
{
    public class GetParametersForOperationByOperationIdQueryHandler:IRequestHandler<GetParametersForOperationByOperationIdQuery, ResponseBaseDto>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<List<OperationParameterDto>> _baseHelper = new BaseHelpers<List<OperationParameterDto>>();

        public GetParametersForOperationByOperationIdQueryHandler(IOperationParameterRepositor operationParameterRepository)
            => (_operationParameterRepository) = (operationParameterRepository);

        public async Task<ResponseBaseDto> Handle(GetParametersForOperationByOperationIdQuery request, CancellationToken cancellationToken)
        {

            var pararmeterList = new List<OperationParameterDto>();
            await foreach (var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId))
            {
                pararmeterList.Add(_baseHelper.ConvertOperationParameterModelToDTO(entry));
            }
            if (pararmeterList.Count == 0)
                return _baseHelper.FormMessageResponse("Error","В данном типе операции нет параметров");

            return _baseHelper.FormOkResponse(pararmeterList);
        }
    }
}
