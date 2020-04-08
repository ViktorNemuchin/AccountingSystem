using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Services.Helpers
{
    /// <summary>
    /// Класс вспомогательных методов
    /// </summary>
    /// <typeparam name="T">Тип результата запроса или команд</typeparam>
    public class BaseHelpers<T> where T : class
    {
        /// <summary>
        /// Формирование успешного ответа
        /// </summary>
        /// <param name="result">Результат запроса</param>
        /// <returns>Успешный запрос</returns>
        public ResponseOkDto<T> FormOkResponse(T result) => new ResponseOkDto<T>
        {
            Status = "Ok",
            Result = result
        };
        
        /// <summary>
        /// Создание DTO неудачных запросов или ситемных сообщений
        /// </summary>
        /// <param name="status">Статус запроса</param>
        /// <param name="message">Сообщение</param>
        /// <returns>Неудачный запрос</returns>
        public ResponseMessageDto FormMessageResponse(string status, string message) => new ResponseMessageDto
        {
            Status = status,
            Message = message
        };

        /// <summary>
        /// Конвертирование модели типа операции в DTO 
        /// </summary>
        /// <param name="typeToConvert">Объект модели типа операции </param>
        /// <returns>DTO типа операции</returns>
        public OperationTypeForListDto ConvertOperationTypeModelToDTO(OperationTypeModel typeToConvert) => new OperationTypeForListDto
        {
            OperationtypeId = typeToConvert.Id,
            OperationTypeName = typeToConvert.OperationTypeName
        };

        /// <summary>
        /// Конвертирование модели правила в DTO для типа операции 
        /// </summary>
        /// <param name="ruleToConvert">Объект модели правила</param>
        /// <returns>DTO правила для типа операции</returns>
        public RuleDto ConvertRuleModelToDTO(RulesModel ruleToConvert) => new RuleDto
        {
            RuleId = ruleToConvert.Id,
            SourceAccount = ruleToConvert.SourceAccount,
            DestinationAccount = ruleToConvert.DestinationAccount,
            RuleOrderNumber = ruleToConvert.RuleOrderNumber,
            Description = ruleToConvert.Description,
            Formula = ruleToConvert.Formula,
            DateFrom = ruleToConvert.DateFrom,
            OperationTypeId = ruleToConvert.OperationTypeId
        };

        /// <summary>
        /// Формирование DTO типа операции
        /// </summary>
        /// <param name="rules">Список правил</param>
        /// <param name="parameters">Список параметров</param>
        /// <param name="operationType">Тип операции</param>
        /// <returns>DTO типа операции</returns>
        public OperationTypeDto ConvertOperationTypeModelToDTO(List<RuleDto> rules, List<OperationParameterDto> parameters, OperationTypeModel operationType) => new OperationTypeDto
        {
            OperationTypeName = operationType.OperationTypeName,
            Rules = rules,
            OperationParameters = parameters
        };

        /// <summary>
        /// Формирование DTO параметра типа операции из модели параметра операции   
        /// </summary>
        /// <param name="operationParameter">Модель параметра типа операции</param>
        /// <returns>DTO параметра типа операции</returns>
        public OperationParameterDto ConvertOperationParameterModelToDTO(OperationParameterModel operationParameter) => new OperationParameterDto
        {
            OperationParameterValue = operationParameter.OperationParameterValue,
            OperationParameterName = operationParameter.OperationParameterName,
            OperationTypeId = operationParameter.OperationTypeId,
            OperationParameterId = operationParameter.Id
        };

        /// <summary>
        /// Конвертирование DTO правил типа операции в модель
        /// </summary>
        /// <param name="rule">DTO правила операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <returns>Модель типа операции</returns>
        public RulesModel ConvertOperationRuleDtoToModel(TransferRuleForUpdateDto rule,Guid operationTypeId) => 
            new RulesModel(rule.RuleId, rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, rule.DateFrom, operationTypeId);

        /// <summary>
        /// Конвертирование DTO правил типа операции в модель
        /// </summary>
        /// <param name="rule">DTO правила</param>
        /// <param name="dateFrom">Дата начала действия правила</param>
        /// <returns>Модель правил операции</returns>
        public RulesModel ConvertOperationRuleDtoToModel(RuleDto rule, DateTimeOffset dateFrom) =>
            new RulesModel(rule.RuleId,rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, dateFrom, rule.OperationTypeId);

        /// <summary>
        /// Конвертирование DTO правил типа операции в модель
        /// </summary>
        /// <param name="rule">DTO правил</param>
        /// <param name="operationTypeId">ID типа операции</param>
        /// <param name="dateFrom">Дата начала действия правила</param>
        /// <returns>Модель правила операции</returns>
        public RulesModel ConvertOperationRuleDtoToModel(TransferRuleDto rule,Guid operationTypeId ,  DateTimeOffset dateFrom) =>
            new RulesModel(rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, dateFrom, operationTypeId);

        /// <summary>
        /// Конвертирование DTO параметра типа операции в модель 
        /// </summary>
        /// <param name="operationParameter">DTO параметра типа операции</param>
        /// <param name="operationTypeId">ID типа операции</param>
        /// <returns>Модель параметра  типа операции</returns>
        public OperationParameterModel ConverParameterDtoToModel(TransferOperationParameterForUpdateDto operationParameter, Guid operationTypeId) => 
            new OperationParameterModel(operationParameter.OperationParameterId,operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId);
        
        /// <summary>
        /// Конвертирование DTO параметра типа операции в модель
        /// </summary>
        /// <param name="operationParameter">DTO параметра типа операции</param>
        /// <param name="operationTypeId">Id типа операции</param>
        /// <returns>Модель параметра типа операции</returns>
        public OperationParameterModel ConverParameterDtoToModel(TransferOperationParameterDto operationParameter, Guid operationTypeId ) =>
            new OperationParameterModel(operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId);
    }
}
