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
    /// <summary>
    /// Класс обработчика запроса на получение списка параметров типа операции 
    /// </summary>
    public class GetOperationParametersForOperationIdQueryHandler : IRequestHandler<GetParametersForOperationTypeQueryByOperationTypeIdQuery, List<OperationParameterDto>>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<OperationParameterDto> _baseHelper =new BaseHelpers<OperationParameterDto>();

        /// <summary>
        /// Конструктр класса обработчика запроса на получение списка параметров типа операции
        /// </summary>
        /// <param name="operationParameterRepository">Интерфейс методов работы с таблицей параметров для типа операций</param>
        public GetOperationParametersForOperationIdQueryHandler(IOperationParameterRepositor operationParameterRepository) =>
            (_operationParameterRepository) = (operationParameterRepository);

        /// <summary>
        /// Обработчик запроса на получение списка параметров типа операции
        /// </summary>
        /// <param name="request">Запрос на получение списка параметров операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<List<OperationParameterDto>> Handle(GetParametersForOperationTypeQueryByOperationTypeIdQuery request, CancellationToken cancellationToken)
        {

            var pararmeterList = new List<OperationParameterDto>();
            await foreach(var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId, cancellationToken)) 
            {
                pararmeterList.Add(_baseHelper.ConvertOperationParameterModelToDTO(entry));
            }
            if (pararmeterList.Count == 0) 
                return null;
            return pararmeterList;
        }
    }
}
