using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountsTestP.Api.Helpers
{
    /// <summary>
    /// Класс вспомогательных методов для фильтра обработки исключений
    /// </summary>
    public class FilterHelper
    {
        /// <summary>
        /// Конструктор класса вспомогательных методов для фильтра обработки исключений
        /// </summary>
        public FilterHelper() { }
        /// <summary>
        /// Метод обработки исключений при неправильной работе сервисов 
        /// </summary>
        /// <param name="context">Текущий Http контекст</param>
        public void ExceptionHandling(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new ObjectResult(context.Result)
                {
                    StatusCode = 500,
                    Value = context.Exception.Message
                };
                context.ExceptionHandled = true;
            }
        }
        /// <summary>
        /// Метод обработки пустых ответов на запросы 
        /// </summary>
        /// <param name="context">Текущий Http контекст</param>
        public void NoContentHandling(ActionExecutedContext context)
        {
            var result = context.Result as ObjectResult;

            if (result.Value == null)
            {
                context.Result = new ObjectResult(context.Result)
                {
                    StatusCode = 404,
                    Value = "There is no such item"
                };
                context.ExceptionHandled = true;
            }
        }

    }
}
