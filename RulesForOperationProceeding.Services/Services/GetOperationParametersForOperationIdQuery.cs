using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Services.Helpers;


namespace RulesForOperationProceeding.Services.Services
{
    public class GetOperationParametersForOperationIdQueryHandler : IRequestHandler<GetParametersForOperationTypeQueryByOperationTypeIdQuery, List<OperationParameterDto>>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<OperationParameterDto> _baseHelper =new BaseHelpers<OperationParameterDto>();
        public GetOperationParametersForOperationIdQueryHandler(IOperationParameterRepositor operationParameterRepository) =>
            (_operationParameterRepository) = (operationParameterRepository);
        public async Task<List<OperationParameterDto>> Handle(GetParametersForOperationTypeQueryByOperationTypeIdQuery request, CancellationToken cancellationToken)
        {

            var pararmeterList = new List<OperationParameterDto>();
            await foreach(var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId)) 
            {
                pararmeterList.Add(_baseHelper.ConvertOperationParameterModelToDTO(entry));
            }
            if (pararmeterList.Count == 0) 
                return null;
            return pararmeterList;
        }
    }
}
