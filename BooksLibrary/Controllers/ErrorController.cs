﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NullParameter() => View();

        public ActionResult NotFound() =>  View();

        public ActionResult Forbidden() =>  View();
    }
}