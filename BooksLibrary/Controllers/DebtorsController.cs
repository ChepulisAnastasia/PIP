using BooksLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Controllers
{
    public class DebtorsController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Debtors
        public ActionResult Index()
        {
            return View(db.Debtors.ToList());
        }
    }
}