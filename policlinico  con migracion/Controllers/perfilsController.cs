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
    public class perfilsController : Controller
    {
        private Model1 db = new Model1();

        // GET: perfils
        public ActionResult Index()
        {
            var perfil = db.perfil.Include(p => p.especialidad);
            return View(perfil.ToList());
        }

        // GET: perfils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfil perfil = db.perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: perfils/Create
        public ActionResult Create()
        {
            

            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre");
            ViewBag.idexamen = new SelectList(db.examenes, "idexamen", "nombre");
            return View();
        }

        // POST: perfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idperfil,idespecialidad,nombre_perfil,costo,estado")] perfil perfil)
        {
            if (ModelState.IsValid)
            {
             
                    db.SaveChanges();

              
             

                   
               
                return RedirectToAction("Index");
            }

            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", perfil.idespecialidad);
            return View(perfil);
        }

        // GET: perfils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfil perfil = db.perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", perfil.idespecialidad);
            return View(perfil);
        }

        // POST: perfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idperfil,idespecialidad,nombre_perfil,costo,estado")] perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idespecialidad = new SelectList(db.especialidad, "idespecialidad", "nombre", perfil.idespecialidad);
            return View(perfil);
        }

        // GET: perfils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfil perfil = db.perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfil perfil = db.perfil.Find(id);
            db.perfil.Remove(perfil);
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
