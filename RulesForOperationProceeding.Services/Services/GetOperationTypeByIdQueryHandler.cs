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
    /// Класс обработчика запроса на получение типа операции по Id типа операции
    /// </summary>
    public class GetOperationTypeByIdQueryHandler : IRequestHandler<GetOperationTypeByIdQuery, ResponseBaseDto>
    {
        private readonly IMediator _mediator;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly BaseHelpers<OperationTypeDto> _baseHelper = new BaseHelpers<OperationTypeDto>();
        
        /// <summary>
        /// Конструктор класса обработчиков запроса на получение типа операции по Id типа операции
        /// </summary>
        /// <param name="mediator">Интерфейс методов работы с запросами и коммандами</param>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей параметров для типа операции </param>
        public GetOperationTypeByIdQueryHandler(IMediator mediator, IOperationTypeRepository operationTypeRepository) =>
            (_mediator, _operationTypeRepository) = (mediator,operationTypeRepository);

        /// <summary>
        /// Обработчик запроса на получение типа операции по Id типа операции
        /// </summary>
        /// <param name="request">Запрос на получение типа операции по Id тьипа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(GetOperationTypeByIdQuery request, CancellationToken cancellationToken)
        {

            var operation = await _operationTypeRepository.GetOperationTypeById(request.OperationId,cancellationToken);
            var rulesList = await _mediator.Send(new GetRulesForOperationTypeQueryByOperationId(request.OperationId));
            var parameterList = await _mediator.Send(new GetParametersForOperationTypeQueryByOperationTypeIdQuery(request.OperationId));
            if (operation == null)
                return _baseHelper.FormMessageResponse("Error", "Нет такого типа операции");
            if (rulesList == null || rulesList.Count == 0)
                return _baseHelper.FormMessageResponse("Error", "Нет доступных правил");
            if (parameterList == null)
                return _baseHelper.FormMessageResponse("Error", "Не заданны параметры для операции");

            return _baseHelper.FormOkResponse(_baseHelper.ConvertOperationTypeModelToDTO(rulesList,parameterList, operation));
            
        }
    }
}
