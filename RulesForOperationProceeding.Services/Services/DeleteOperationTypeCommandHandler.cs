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
    /// <summary>
    /// Класс обработчика команды удаления типа операции
    /// </summary>
    public class DeleteOperationTypeCommandHandler : IRequestHandler<DeleteOperationTypeCommand, ResponseBaseDto>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IOperationParameterRepositor _operationParameterRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса обоаботчика команды удаления типа операции
        /// </summary>
        /// <param name="operationTypeRepository">Интерфейс методов для работы с таблицей типов операций</param>
        /// <param name="operationParameterRepository">Интерфейс методов для работы с таблицей параметров типа операций</param>
        /// <param name="ruleRepository">Интерфейс методов для работы с таблицей правил</param>
        public DeleteOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IOperationParameterRepositor operationParameterRepository, IRuleRepository ruleRepository) =>
            (_operationTypeRepository, _operationParameterRepository, _ruleRepository) = (operationTypeRepository, operationParameterRepository, ruleRepository);
        /// <summary>
        /// Обработчик команды удаления типа операции
        /// </summary>
        /// <param name="request">Команда удаления типа операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto<TransferResultDto> --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(DeleteOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationTypeById(request.OperationTypeId, cancellationToken);
            if (operationType == null)
                return _baseHelper.FormMessageResponse("Error", "Данный тип операции не найден");
            
            await foreach(var entry in _operationParameterRepository.GetOperationParametersById(request.OperationTypeId, cancellationToken))
                _operationParameterRepository.DeleteOperationParameter(entry);
            

            await foreach(var entry in _ruleRepository.GetRulesForoperationTypeList(request.OperationTypeId, cancellationToken)) 
                _ruleRepository.DeleteRule(entry);

            _operationTypeRepository.DeleteOperationType(operationType);

            await _operationTypeRepository.SaveChangesAsync();

            var result = new TransferResultDto() { Id = operationType.Id, Name = operationType.OperationTypeName};

            return _baseHelper.FormOkResponse(result);
        }
    }
}
