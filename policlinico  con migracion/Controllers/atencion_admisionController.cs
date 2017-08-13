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
    public class atencion_admisionController : Controller
    {
        private Model1 db = new Model1();

        // GET: atencion_admision
        public ActionResult Index()
        {
            var atencion_admision = db.atencion_admision.Include(a => a.empresa).Include(a => a.examenes).Include(a => a.paciente).Include(a => a.perfil).Include(a => a.tipo_examen_ocupacional);
            return View(atencion_admision.ToList());
        }

        // GET: atencion_admision/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atencion_admision atencion_admision = db.atencion_admision.Find(id);
            if (atencion_admision == null)
            {
                return HttpNotFound();
            }
            return View(atencion_admision);
        }

        // GET: atencion_admision/Create
        public ActionResult Create()
        {
            ViewBag.Idempresa = new SelectList(db.empresa, "Idempresa", "sRazon_social");
            ViewBag.idexamenes = new SelectList(db.examenes, "idexamenes", "nombre_examen");
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "area_trabajo");
            ViewBag.idperfil = new SelectList(db.perfil, "idperfil", "nombre_perfil");
            ViewBag.idtipexam = new SelectList(db.tipo_examen_ocupacional, "idtipexam", "descripcion");
            return View();
        }

        // POST: atencion_admision/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idatencion_admi,idtipexam,idpaciente,idpersona,fecha_atencion,estado,tipo_examen,local,idexamenes,idperfil,idarea,Idempresa")] atencion_admision atencion_admision)
        {
            if (ModelState.IsValid)
            {
                db.atencion_admision.Add(atencion_admision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idempresa = new SelectList(db.empresa, "Idempresa", "sRazon_social", atencion_admision.Idempresa);
            ViewBag.idexamenes = new SelectList(db.examenes, "idexamenes", "nombre_examen", atencion_admision.idexamenes);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "area_trabajo", atencion_admision.idpaciente);
            ViewBag.idperfil = new SelectList(db.perfil, "idperfil", "nombre_perfil", atencion_admision.idperfil);
            ViewBag.idtipexam = new SelectList(db.tipo_examen_ocupacional, "idtipexam", "descripcion", atencion_admision.idtipexam);
            return View(atencion_admision);
        }

        // GET: atencion_admision/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atencion_admision atencion_admision = db.atencion_admision.Find(id);
            if (atencion_admision == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idempresa = new SelectList(db.empresa, "Idempresa", "sRazon_social", atencion_admision.Idempresa);
            ViewBag.idexamenes = new SelectList(db.examenes, "idexamenes", "nombre_examen", atencion_admision.idexamenes);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "area_trabajo", atencion_admision.idpaciente);
            ViewBag.idperfil = new SelectList(db.perfil, "idperfil", "nombre_perfil", atencion_admision.idperfil);
            ViewBag.idtipexam = new SelectList(db.tipo_examen_ocupacional, "idtipexam", "descripcion", atencion_admision.idtipexam);
            return View(atencion_admision);
        }

        // POST: atencion_admision/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idatencion_admi,idtipexam,idpaciente,idpersona,fecha_atencion,estado,tipo_examen,local,idexamenes,idperfil,idarea,Idempresa")] atencion_admision atencion_admision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atencion_admision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idempresa = new SelectList(db.empresa, "Idempresa", "sRazon_social", atencion_admision.Idempresa);
            ViewBag.idexamenes = new SelectList(db.examenes, "idexamenes", "nombre_examen", atencion_admision.idexamenes);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "area_trabajo", atencion_admision.idpaciente);
            ViewBag.idperfil = new SelectList(db.perfil, "idperfil", "nombre_perfil", atencion_admision.idperfil);
            ViewBag.idtipexam = new SelectList(db.tipo_examen_ocupacional, "idtipexam", "descripcion", atencion_admision.idtipexam);
            return View(atencion_admision);
        }

        // GET: atencion_admision/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atencion_admision atencion_admision = db.atencion_admision.Find(id);
            if (atencion_admision == null)
            {
                return HttpNotFound();
            }
            return View(atencion_admision);
        }

        // POST: atencion_admision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atencion_admision atencion_admision = db.atencion_admision.Find(id);
            db.atencion_admision.Remove(atencion_admision);
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
