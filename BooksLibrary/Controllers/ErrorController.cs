using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NullParameter()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}