using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using policlinico__con_migracion.Migracion;
using policlinico__con_migracion.Models;

namespace policlinico__con_migracion.Controllers
{
    public class tipo_examen_ocupacionalController : Controller
    {//todo: usuario y contraseña; admin _Aa1234
        //TODO:  quiero usar ek tracker pero me manda un error al momento de ejecucion con respesto a los  roles   
        private Model1 db = new Model1();

        // GET: tipo_examen_ocupacional
        public ActionResult Index()
        {
            return View(db.tipo_examen_ocupacional.ToList());
        }

        // GET: tipo_examen_ocupacional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_examen_ocupacional tipo_examen_ocupacional = db.tipo_examen_ocupacional.Find(id);
            if (tipo_examen_ocupacional == null)
            {
                return HttpNotFound();
            }
            return View(tipo_examen_ocupacional);
        }

        // GET: tipo_examen_ocupacional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_examen_ocupacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipexam,descripcion")] tipo_examen_ocupacional tipo_examen_ocupacional)
        {
            if (ModelState.IsValid)
            {
                db.tipo_examen_ocupacional.Add(tipo_examen_ocupacional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_examen_ocupacional);
        }

        // GET: tipo_examen_ocupacional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_examen_ocupacional tipo_examen_ocupacional = db.tipo_examen_ocupacional.Find(id);
            if (tipo_examen_ocupacional == null)
            {
                return HttpNotFound();
            }
            return View(tipo_examen_ocupacional);
        }

        // POST: tipo_examen_ocupacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipexam,descripcion")] tipo_examen_ocupacional tipo_examen_ocupacional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_examen_ocupacional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_examen_ocupacional);
        }

        // GET: tipo_examen_ocupacional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_examen_ocupacional tipo_examen_ocupacional = db.tipo_examen_ocupacional.Find(id);
            if (tipo_examen_ocupacional == null)
            {
                return HttpNotFound();
            }
            return View(tipo_examen_ocupacional);
        }

        // POST: tipo_examen_ocupacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_examen_ocupacional tipo_examen_ocupacional = db.tipo_examen_ocupacional.Find(id);
            db.tipo_examen_ocupacional.Remove(tipo_examen_ocupacional);
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
