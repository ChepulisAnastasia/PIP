using BooksLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace BooksLibrary.Controllers
{
    public class DebtorsController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Debtors
        /*public ActionResult Index()
        {
            return View(db.Debtors.ToList());
        }*/
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            List<Debtor> debtor = db.Debtors.ToList();
            return View(debtor.ToPagedList(pageNumber, pageSize));
        }
    }
}