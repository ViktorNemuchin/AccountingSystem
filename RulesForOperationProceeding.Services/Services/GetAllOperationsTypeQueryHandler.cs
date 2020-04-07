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
    /// <summary>
    /// Класс обработчика запроса всех типов операции
    /// </summary>
    public class GetAllOperationsTypeQueryHandler : IRequestHandler<GetAllOperationTypes, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<List<OperationTypeForListDto>> _baseHelpers = new BaseHelpers<List<OperationTypeForListDto>>();
        
        /// <summary>
        /// Конструктор класса обработчика запроса всех типов операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов работы с таблицей типов операции</param>
        public GetAllOperationsTypeQueryHandler(IOperationTypeRepository operationTypeRepository) => (_operationTypeRepository) = (operationTypeRepository);

        /// <summary>
        /// обработчик запроса всех типов операции
        /// </summary>
        /// <param name="request">Запрос всех типов операции </param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetAllOperationTypes request, CancellationToken cancellationToken)
        {
            var operationTypeList = new List<OperationTypeForListDto>();
            await foreach(var entry in _operationTypeRepository.GetAllOperationtypes(cancellationToken))
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
