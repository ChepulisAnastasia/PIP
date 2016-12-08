using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Controllers
{
    public class DebtorsController : Controller
    {
        // GET: Debtors
        public ActionResult Index()
        {
            return View();
        }
    }
}