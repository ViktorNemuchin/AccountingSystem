using AccountsTestP.Api.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountsTestP.Api.Filters
{
    /// <summary>
    /// Класс фильтра обработки исключений
    /// </summary>
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly FilterHelper _helper;
        /// <summary>
        /// Конструктор фильтра обработки исключений  
        /// </summary>
        public HttpResponseExceptionFilter()
        {
            _helper = new FilterHelper();
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
            _helper.ExceptionHandling(context);
            _helper.NoContentHandling(context);
        }
    }
}
