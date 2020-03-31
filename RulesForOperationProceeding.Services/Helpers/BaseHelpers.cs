using RulesForOperationProceeding.Domain.DTOS;
using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Services.Helpers
{
    public class BaseHelpers<T> where T : class
    {
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
        /// <returns></returns>
        public ResponseMessageDto FormMessageResponse(string status, string message) => new ResponseMessageDto
        {
            Status = status,
            Message = message
        };

        public OperationTypeForListDto ConvertOperationTypeModelToDTO(OperationTypeModel typeToConvert) => new OperationTypeForListDto
        {
            OperationtypeId = typeToConvert.Id,
            OperationTypeName = typeToConvert.OperationTypeName
        };
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
        public OperationTypeDto ConvertOperationTypeModelToDTO(List<RuleDto> rules, List<OperationParameterDto> parameters, OperationTypeModel operationType) => new OperationTypeDto
        {
            OperationTypeName = operationType.OperationTypeName,
            Rules = rules,
            OperationParameters = parameters
        };
        public OperationParameterDto ConvertOperationParameterModelToDTO(OperationParameterModel operationParameter) => new OperationParameterDto
        {
            OperationParameterValue = operationParameter.OperationParameterValue,
            OperationParameterName = operationParameter.OperationParameterName,
            OperationTypeId = operationParameter.OperationTypeId,
            OperationParameterId = operationParameter.Id
        };
        public RulesModel ConvertOperationRuleDtoToModel(TransferRuleForUpdateDto rule,Guid operationTypeId) => 
            new RulesModel(rule.RuleId, rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, rule.DateFrom, operationTypeId);
        public RulesModel ConvertOperationRuleDtoToModel(RuleDto rule, DateTimeOffset dateFrom) =>
            new RulesModel(rule.RuleId,rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, dateFrom, rule.OperationTypeId);
        public RulesModel ConvertOperationRuleDtoToModel(TransferRuleDto rule,Guid operationTypeId ,  DateTimeOffset dateFrom) =>
            new RulesModel(rule.SourceAccount, rule.DestinationAccount,rule.RuleOrderNumber, rule.Formula, rule.Description, dateFrom, operationTypeId);

        public OperationParameterModel ConverParameterDtoToModel(TransferOperationParameterForUpdateDto operationParameter, Guid operationTypeId) => 
            new OperationParameterModel(operationParameter.OperationParameterId,operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId);
        public OperationParameterModel ConverParameterDtoToModel(TransferOperationParameterDto operationParameter, Guid operationTypeId ) =>
            new OperationParameterModel(operationParameter.OperationParameterName, operationParameter.OperationParameterValue, operationTypeId);
    }
}
