using System.Collections.Generic;
using System.Data;
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
    public class ExtraditionsController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Extraditions
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            List<Extradition> book = db.Extraditions.ToList();
            return View(book.ToPagedList(pageNumber, pageSize));
        }

        // GET: Extraditions/Create
        public ActionResult Create()
        {
            ViewBag.instance_id = new SelectList(db.Instances.Where(item => item.existence == "да"), "id", "ISBN");
            ViewBag.reader_id = new SelectList(db.Readers, "id", "last_name");
            return View();
        }

        // POST: Extraditions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,instance_id,reader_id,date_extradition,return_date")] Extradition extradition)
        {
            if (ModelState.IsValid)
            {
                db.Extraditions.Add(extradition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.instance_id = new SelectList(db.Instances, "id", "ISBN", extradition.instance_id);
            ViewBag.reader_id = new SelectList(db.Readers, "id", "last_name", extradition.reader_id);
            return View(extradition);
        }

        // GET: Extraditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extradition extradition = db.Extraditions.Find(id);
            if (extradition == null)
            {
                return HttpNotFound();
            }
            ViewBag.instance_id = new SelectList(db.Instances, "id", "ISBN", extradition.instance_id);
            ViewBag.reader_id = new SelectList(db.Readers, "id", "last_name", extradition.reader_id);
            return View(extradition);
        }

        // POST: Extraditions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,instance_id,reader_id,date_extradition,return_date")] Extradition extradition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extradition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.instance_id = new SelectList(db.Instances, "id", "existence", extradition.instance_id);
            ViewBag.reader_id = new SelectList(db.Readers, "id", "last_name", extradition.reader_id);
            return View(extradition);
        }

        // GET: Extraditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extradition extradition = db.Extraditions.Find(id);
            if (extradition == null)
            {
                return HttpNotFound();
            }
            return View(extradition);
        }

        // POST: Extraditions/Delete/5
        [HttpPost]
        public void DeleteConfirmed(int id)
        {
            Extradition extradition = db.Extraditions.Find(id);
            db.Extraditions.Remove(extradition);
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
