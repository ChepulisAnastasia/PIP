using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter

    {
        public void OnException(ExceptionContext filterContext)
        {
            switch (filterContext.Exception.Message)
            {
                case "400":
                {
                        filterContext.Result = new RedirectResult("~/Error/NullParameter");
                        filterContext.ExceptionHandled = true;
                    break;
                }
                case "403":
                {
                        filterContext.Result = new RedirectResult("~/Error/Forbidden");
                        filterContext.ExceptionHandled = true;
                        break;
                }
                case "404":
                {
                        filterContext.Result = new RedirectResult("~/Error/NotFound");
                        filterContext.ExceptionHandled = true;
                    break;
                }
            }
        }
    }
}
