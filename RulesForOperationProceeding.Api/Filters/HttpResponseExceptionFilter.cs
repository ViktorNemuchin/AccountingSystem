using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using RulesForOperationProceeding.Api.Helpers;
namespace RulesForOperationProceeding.Api.Filters
{
    /// <summary>
    /// Класс фильтра обработки исключений
    /// </summary>
    public class HttpResponseExceptionFilter: IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// Конструктор класса вспомогательных методов для фильтра обработки исключений
        /// </summary>
        public HttpResponseExceptionFilter() 
        {
        }
        /// <summary>
        /// Порядок обработки
        /// </summary>
        public int Order { get; set; } = 1;
        /// <summary>
        /// Переопределяемый метод обработки исключений при выполненинии запроса
        /// </summary>
        /// <param name="context">Текущий Http контекст</param>
        public void OnActionExecuting(ActionExecutingContext context) 
        {
        }
        /// <summary>
        /// Переопределяемый метод обработки исключений по результатм выполнения запроса
        /// </summary>
        /// <param name="context">Текущий Http контекст</param>
        public void OnActionExecuted(ActionExecutedContext context) 
        {
            ExceptionFilterHelper.ExceptionHandling(context);
        }
    }
}
