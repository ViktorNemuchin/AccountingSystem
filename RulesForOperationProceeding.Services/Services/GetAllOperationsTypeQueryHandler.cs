using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RulesForOperationProceeding.Services.Helpers;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Domain.DTOS;
using System.Threading.Tasks;
using System.Threading;

namespace RulesForOperationProceeding.Services.Services
{
    public class GetAllOperationsTypeQueryHandler : IRequestHandler<GetAllOperationTypes, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<List<OperationTypeForListDto>> _baseHelpers = new BaseHelpers<List<OperationTypeForListDto>>();
        public GetAllOperationsTypeQueryHandler(IOperationTypeRepository operationTypeRepository) => (_operationTypeRepository) = (operationTypeRepository);
        public async Task<ResponseBaseDto> Handle(GetAllOperationTypes request, CancellationToken cancellationToken)
        {
            var operationTypeList = new List<OperationTypeForListDto>();
            await foreach(var entry in _operationTypeRepository.GetAllOperationtypes())
            {
                var operationType = _baseHelpers.ConvertOperationTypeModelToDTO(entry);
                operationTypeList.Add(operationType);
            }
            if (operationTypeList.Count !=0)
                return _baseHelpers.FormOkResponse(operationTypeList);

            return _baseHelpers.FormMessageResponse("Error", "Нет доступных типов опреций");
        }
    }
}
