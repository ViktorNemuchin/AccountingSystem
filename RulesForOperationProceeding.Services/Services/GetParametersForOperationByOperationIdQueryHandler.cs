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
    /// <summary>
    /// Класс обработчика запроса на получение параметра для типов операции
    /// </summary>
    public class GetParametersForOperationByOperationIdQueryHandler:IRequestHandler<GetParametersForOperationByOperationIdQuery, ResponseBaseDto>
    {
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly BaseHelpers<List<OperationParameterDto>> _baseHelper = new BaseHelpers<List<OperationParameterDto>>();

        /// <summary>
        /// Конструктор класса обработчика запроса на получение параметра для типов операции
        /// </summary>
        /// <param name="operationParameterRepository">Интерфейс методов работы с таблицей параметров для типа операций</param>
        public GetParametersForOperationByOperationIdQueryHandler(IOperationParameterRepositor operationParameterRepository)
            => (_operationParameterRepository) = (operationParameterRepository);

        /// <summary>
        /// Обработчик запроса на получение параметра для типа операции
        /// </summary>
        /// <param name="request">Запрос на получение параметра для типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetParametersForOperationByOperationIdQuery request, CancellationToken cancellationToken)
        {

            var pararmeterList = new List<OperationParameterDto>();
            await foreach (var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId, cancellationToken))
            {
                pararmeterList.Add(_baseHelper.ConvertOperationParameterModelToDTO(entry));
            }
            if (pararmeterList.Count == 0)
                return _baseHelper.FormMessageResponse("Error","В данном типе операции нет параметров");

            return _baseHelper.FormOkResponse(pararmeterList);
        }
    }
}
