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
    public class medicosController : Controller
    {
        private Model1 db = new Model1();

        // GET: medicos
        public ActionResult Index()
        {
            var medico = db.medico.Include(m => m.especialidad);
            return View(medico.ToList());
        }

        // GET: medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: medicos/Create
        public ActionResult Create()
        {
            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre");
            return View();
        }

        // POST: medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmedico,idespecialidad,cmp_rne,fecha_alta,fecha_baja,nombre,apellidos")] medico medico)
        {
            if (ModelState.IsValid)
            {
                db.medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", medico.idespecialidad);
            return View(medico);
        }

        // GET: medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", medico.idespecialidad);
            return View(medico);
        }

        // POST: medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmedico,idespecialidad,cmp_rne,fecha_alta,fecha_baja,nombre,apellidos")] medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", medico.idespecialidad);
            return View(medico);
        }

        // GET: medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medico medico = db.medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medico medico = db.medico.Find(id);
            db.medico.Remove(medico);
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
