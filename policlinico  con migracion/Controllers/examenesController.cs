using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using policlinico__con_migracion.Migracion;
// creada por hilton 
//controlador de examenes  para  usar el  crud  de la identidad examen
namespace policlinico__con_migracion.Controllers
{
    public class examenesController : Controller
    {
        private Model1 db = new Model1();

        // GET: examenes
        public ActionResult Index()
        {
            return View(db.examenes.ToList());
        }

        // GET: examenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examenes examenes = db.examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // GET: examenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idexamenes,nombre_examen,costo,recomendaciones")] examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.examenes.Add(examenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examenes);
        }

        // GET: examenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examenes examenes = db.examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // POST: examenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idexamenes,nombre_examen,costo,recomendaciones")] examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examenes);
        }

        // GET: examenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examenes examenes = db.examenes.Find(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // POST: examenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            examenes examenes = db.examenes.Find(id);
            db.examenes.Remove(examenes);
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
