using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BooksLibrary.Models;
using PagedList.Mvc;
using PagedList;
using System.Collections.Generic;

namespace BooksLibrary.Controllers
{
    [Authorize]
    [Filters.ActionFilter]
    [Filters.ExceptionFilter]
    public class BooksController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Books
        /*public ActionResult Index()
        {
            return View(db.Books.ToList());
        }*/

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            List<Book> book = db.Books.ToList();
            return View(book.ToPagedList(pageNumber, pageSize));
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                throw new Exception("400");
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                throw new Exception("404");
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "ISBN,author,name,publication_type,tome,compiler,language,translator,place_publication,publishing,year,number,price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                throw new Exception("400");
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                throw new Exception("404");
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "ISBN,author,name,publication_type,tome,compiler,language,translator,place_publication,publishing,year,number,price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Book book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception("403");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
