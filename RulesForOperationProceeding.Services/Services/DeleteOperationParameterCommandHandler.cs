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
    /// Класс обработчика комманды удаления параметра операции
    /// </summary>
    public class DeleteOperationParameterCommandHandler : IRequestHandler<DeleteOperationParameterCommand, ResponseBaseDto>
    {
        /// <summary>
        /// Экземпляр класса методов работы с таблицами параметров типа операции
        /// </summary>
        private readonly IOperationParameterRepositor _operationParameterRepository;

        /// <summary>
        /// Базовый класс вспомогательных методов
        /// </summary>
        private readonly BaseHelpers<TransferResultDto> _baseHelper = new BaseHelpers<TransferResultDto>();

        /// <summary>
        /// Конструктор класса обработчика комманды удаления параметра операции
        /// </summary>
        /// <param name="operationParameterRepository">Класс методов работы с таблицами параметров типа операции</param>
        public DeleteOperationParameterCommandHandler(IOperationParameterRepositor operationParameterRepository) => (_operationParameterRepository) = (operationParameterRepository);
        /// <summary>
        /// Обработчик команды удаления параметров операции
        /// </summary>
        /// <param name="request">Комманда удаления параметра операции</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ResponseOKDto<TransferResultDto> --- Результат успешного выполнения запроса</returns>
        /// <returns>ResponseMessageDto ----- Результат ошибки при выполнении запроса</returns>
        public async Task<ResponseBaseDto> Handle(DeleteOperationParameterCommand request, CancellationToken cancellationToken)
        {
            var operationParameter = await _operationParameterRepository.GetOperationParameter(request.OperationParameterId, cancellationToken);
            if (operationParameter == null)
                return _baseHelper.FormMessageResponse("Error", "Данное правило не найдено");
            _operationParameterRepository.DeleteOperationParameter(operationParameter);
            await _operationParameterRepository.SaveChangesAsync();
            var result = new TransferResultDto() { Id = operationParameter.Id, Name = operationParameter.OperationParameterName };
            return _baseHelper.FormOkResponse(result);
        }
    }
}
