using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksLibrary.Models;
using PagedList;

namespace BooksLibrary.Controllers
{
    [Authorize]
    [Authorize(Roles = "Manager")]
    [Filters.ActionFilter]
    [Filters.ExceptionFilter]
    public class ReadersController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Readers
        /*public ActionResult Index()
        {
            return View(db.Readers.ToList());
        }*/

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            List<Reader> reader = db.Readers.ToList();
            return View(reader.ToPagedList(pageNumber, pageSize));
        }

        // GET: Readers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,last_name,name,middle_name,age,address,phone")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Readers.Add(reader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reader);
        }

        // GET: Readers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Readers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,last_name,name,middle_name,age,address,phone")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        // GET: Readers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost]
        public void DeleteConfirmed(int id)
        {
            Reader reader = db.Readers.Find(id);
            db.Readers.Remove(reader);
            db.SaveChanges();
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
