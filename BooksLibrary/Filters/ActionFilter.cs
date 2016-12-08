using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Filters
{
    public class ActionFilter : FilterAttribute, IActionFilter, IResultFilter
    {
        /// <summary>
        /// Обращение к методу
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //using (StreamWriter file = File.AppendText(@"D:\log.txt"))
            //{
            //    var userName = string.IsNullOrEmpty(filterContext.RequestContext.HttpContext.User.Identity.Name)
            //        ? "Anonymous"
            //        : filterContext.RequestContext.HttpContext.User.Identity.Name;

            //    file.WriteLine();
            //    file.WriteLine($"Time: {DateTime.Now}");
            //    file.WriteLine($"User: {userName}");
            //    file.WriteLine($"URL: {filterContext.HttpContext.Request.Url}");
            //    file.WriteLine($"Controller name: {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}");
            //    file.WriteLine($"Action name: {filterContext.ActionDescriptor.ActionName} (start time: {DateTime.Now.ToString("HH.mm.ss.ffffff")})");
            //}
        }

        /// <summary>
        /// Завершение отработки метода
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //using (StreamWriter file = File.AppendText(@"D:\log.txt"))
            //{
            //    file.WriteLine($"Action name: {filterContext.ActionDescriptor.ActionName} (end time: {DateTime.Now.ToString("HH.mm.ss.ffffff")})");
            //}
        }

        /// <summary>
        /// Начало рендера страницы
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //using (StreamWriter file = File.AppendText(@"D:\log.txt"))
            //{
            //    file.WriteLine($"Render page start: {DateTime.Now.ToString("HH.mm.ss.ffffff")}");
            //}
        }

        /// <summary>
        /// Окончание рендера страницы
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //using (StreamWriter file = File.AppendText(@"D:\log.txt"))
            //{
            //    file.WriteLine($"Render page end: {DateTime.Now.ToString("HH.mm.ss.ffffff")})");
            //}
        }
    }
}