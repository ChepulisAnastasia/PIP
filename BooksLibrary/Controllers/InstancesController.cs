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
    public class InstancesController : Controller
    {
        private LibraryDatabaseEntities db = new LibraryDatabaseEntities();

        // GET: Instances
        /*public ActionResult Index()
        {
            var instances = db.Instances.Include(i => i.Book);
            return View(instances.ToList());
        }*/

        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var instances = db.Instances.Include(i => i.Book);
            return View((instances.ToList()).ToPagedList(pageNumber, pageSize));
        }

        // GET: Instances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // GET: Instances/Create
        public ActionResult Create()
        {
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "name");
            return View();
        }

        // POST: Instances/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,room,rack,shelf,existence,ISBN")] Instance instance)
        {
            if (ModelState.IsValid)
            {
                db.Instances.Add(instance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "name", instance.ISBN);
            return View(instance);
        }

        // GET: Instances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "name", instance.ISBN);
            return View(instance);
        }

        // POST: Instances/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,room,rack,shelf,existence,ISBN")] Instance instance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN = new SelectList(db.Books, "ISBN", "name", instance.ISBN);
            return View(instance);
        }

        // POST: Instances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instance instance = db.Instances.Find(id);
            db.Instances.Remove(instance);
            db.SaveChanges();
            return RedirectToAction("Index");
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
