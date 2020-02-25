using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountsTestP.Api.Helpers
{
    public class FilterHelper
    {
        public FilterHelper() { }
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
