using System;
using System.Collections.Generic;
using System.Text;
using RulesForOperationProceeding.Domain.DTOS;

namespace RulesForOperationProceeding.Domain.Command
{
    /// <summary>
    /// Класс команды изменения типа операции
    /// </summary>
    public class UpdateOperationTypeCommand:BaseCommand<ResponseBaseDto>
    {
        /// <summary>
        /// Id типа операции
        /// </summary>
        public Guid OperationTypeId { get; private set; }

        /// <summary>
        /// Название типа операции
        /// </summary>
        public string OperationTypeName { get; private set; }

        /// <summary>
        /// Список параметров операции
        /// </summary>
        public List<TransferOperationParameterForUpdateDto> OperationParameters { get; private set; }

        /// <summary>
        /// Список правил типа операции
        /// </summary>
        public List<TransferRuleForUpdateDto> Rules { get; private set; }

        /// <summary>
        /// Конструктор класса изменения данных типа операции
        /// </summary>
        /// <param name="operationTypeId">Id  типа операции</param>
        /// <param name="operationTypeName">Название типа операции</param>
        /// <param name="operationTypeParameters">Список параметров типа операции</param>
        /// <param name="rules">Список правил типа операции</param>
        public UpdateOperationTypeCommand(Guid operationTypeId, string operationTypeName, List<TransferOperationParameterForUpdateDto> operationTypeParameters, List<TransferRuleForUpdateDto> rules) =>
            (OperationTypeId, OperationTypeName, OperationParameters, Rules) 
            = (operationTypeId, operationTypeName, operationTypeParameters, rules);
    }
}
