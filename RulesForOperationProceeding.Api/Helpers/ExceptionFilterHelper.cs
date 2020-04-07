using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesForOperationProceeding.Domain.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace RulesForOperationProceeding.Api.Helpers
{
    /// <summary>
    /// Статический класс вспомогательных методов для фильтра обработки исключений
    /// </summary>
    public static class ExceptionFilterHelper
    {
        /// <summary>
        /// Метод обработки исключений при внутренней ошибке работе сервисов 
        /// </summary>
        /// <param name="context">Текущий Http контекст</param>
        public static void ExceptionHandling(ActionExecutedContext context) 
        {
            if (context.Exception != null) 
            {
                context.Result = new ObjectResult(context.Result)
                {
                    StatusCode = 500,
                    Value = new ResponseMessageDto
                    {
                        Status = "Error",
                        Message = context.Exception.Message
                    }
                };
                context.ExceptionHandled = true;

            }
        }
    }
}
