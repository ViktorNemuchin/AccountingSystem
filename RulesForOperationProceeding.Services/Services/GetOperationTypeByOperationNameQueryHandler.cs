using MediatR;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Queries;
using RulesForOperationProceeding.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Services.Services
{
    /// <summary>
    /// Класс обработчика запроса на получение типа операции по названию типа операции
    /// </summary>
    public class GetOperationTypeByOperationTypeNameQueryHandler : IRequestHandler<GetOperationTypeByOperationTypeNameQuery,ResponseBaseDto>
    {
        private readonly IMediator _mediator;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<OperationTypeDto> _baseHelper = new BaseHelpers<OperationTypeDto>();

        /// <summary>
        /// Конструктор класса обработчиков запроса на получение типа операции по названию типа операции
        /// </summary>
        /// <param name="mediator">Интерфейс методов работы с запросами и коммандами</param>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей параметров для типа операции</param>
        public GetOperationTypeByOperationTypeNameQueryHandler(IMediator mediator, IOperationTypeRepository operationTypeRepository)
            => (_mediator, _operationTypeRepository) = (mediator, operationTypeRepository);

        /// <summary>
        /// Обработчика запроса на получение типа операции по названию типа операции
        /// </summary>
        /// <param name="request">Запроса на получение типа операции по названию типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetOperationTypeByOperationTypeNameQuery request, CancellationToken cancellationToken)
        {
            var operation = await _operationTypeRepository.GetOperationTypeByName(request.OperationTypeName, cancellationToken);
            if (operation == null)
                return _baseHelper.FormMessageResponse("Error", "Нет такого типа операции");
            var rulesList = await _mediator.Send(new GetRulesForOperationTypeQueryByOperationId(operation.Id));
            var parameterList = await _mediator.Send(new GetParametersForOperationTypeQueryByOperationTypeIdQuery(operation.Id));
            if (rulesList == null || rulesList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Нет доступных правил");
            if (parameterList == null)
                return _baseHelper.FormMessageResponse("Error", "Не заданны параметры для операции");

            return _baseHelper.FormOkResponse(_baseHelper.ConvertOperationTypeModelToDTO(rulesList, parameterList, operation));
        }
    }
}
