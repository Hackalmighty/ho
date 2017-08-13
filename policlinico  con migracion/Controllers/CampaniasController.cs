using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using policlinico__con_migracion.Migracion;

namespace policlinico__con_migracion.Controllers
{
    public class CampaniasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Campanias
        public ActionResult Index()
        {
            return View(db.Campanias.ToList());
        }

        // GET: Campanias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanias campanias = db.Campanias.Find(id);
            if (campanias == null)
            {
                return HttpNotFound();
            }
            return View(campanias);
        }

        // GET: Campanias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campanias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCampania,Nombre,FechaPlan,Fecha,Publicada")] Campanias campanias)
        {
            if (ModelState.IsValid)
            {
                db.Campanias.Add(campanias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campanias);
        }

        // GET: Campanias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanias campanias = db.Campanias.Find(id);
            if (campanias == null)
            {
                return HttpNotFound();
            }
            return View(campanias);
        }

        // POST: Campanias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCampania,Nombre,FechaPlan,Fecha,Publicada")] Campanias campanias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campanias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campanias);
        }

        // GET: Campanias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanias campanias = db.Campanias.Find(id);
            if (campanias == null)
            {
                return HttpNotFound();
            }
            return View(campanias);
        }

        // POST: Campanias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campanias campanias = db.Campanias.Find(id);
            db.Campanias.Remove(campanias);
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
