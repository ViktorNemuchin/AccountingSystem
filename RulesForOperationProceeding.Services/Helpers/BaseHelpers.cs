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

            SourceAccount = ruleToConvert.SourceAccount,
            DestinationAccount = ruleToConvert.DestinationAccount,
            Description = ruleToConvert.Description,
            Formula = ruleToConvert.Formula,
            DateFrom = ruleToConvert.DateFrom,
            OperationTypeId = ruleToConvert.OperationTypeId
        };
        public OperationTypeDto ConvertOperationTypeModelToDTO(List<RuleDto> rules, OperationTypeModel operationType) => new OperationTypeDto
        {
            OperationName = operationType.OperationTypeName,
            Rules = rules
        }; 
    }
}
