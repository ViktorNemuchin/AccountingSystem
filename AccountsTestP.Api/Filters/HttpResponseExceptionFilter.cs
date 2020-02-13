using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountsTestP.Api.Helpers;

namespace AccountsTestP.Api.Filters
{
    public class HttpResponseExceptionFilter :  IActionFilter, IOrderedFilter
    {
        private readonly FilterHelper _helper;
        public HttpResponseExceptionFilter() 
        {
            _helper = new FilterHelper();
        }
        public int Order { get; set; } = 1;

     
        public void OnActionExecuting(ActionExecutingContext context) 
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _helper.ExceptionHandling(context);
            _helper.NoContentHandling(context);
        }
    }
}
