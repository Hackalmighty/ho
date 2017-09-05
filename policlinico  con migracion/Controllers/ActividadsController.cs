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
    public class ActividadsController : Controller
    {
        private Model1 db = new Model1();

        public JsonResult Eventos(DateTime start, DateTime end)
        {
            var actividades = (from a in db.Actividads
                               join c in db.empresa
                                   on a.Idempresa equals c.Idempresa
                               where a.FechaInicial >= start
                               && a.FechaInicial <= end
                               select new 
                               {
                                   a.IdActividad,
                                   a.FechaInicial,
                                   c.sRazon_social,
                                   a.Descripcion
                               }).ToList();
            List<Events> eventos = new List<Events>();
            foreach (var item in actividades)
            {
                Events evento = new Events();
                evento.id = item.IdActividad;
                evento.start = item.FechaInicial.ToString("o");
                evento.end = item.FechaInicial.ToString("o");
                evento.title = item.sRazon_social + " " + item.Descripcion;
                eventos.Add(evento);
            }
            return Json(eventos, JsonRequestBehavior.AllowGet);
        }
        // GET: Actividads
        public ActionResult Index()
        {
            return View(db.Actividads.ToList());
        }

        // GET: Actividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividads actividads = db.Actividads.Find(id);
            if (actividads == null)
            {
                return HttpNotFound();
            }
            return View(actividads);
        }

        // GET: Actividads/Create
        public ActionResult Create()
        {
            var tipos = new SelectList(db.tipo_examen_ocupacional.ToList(), "idtipexam", "descripcion");
            ViewData["tipos"] = tipos;
            return PartialView();
        }

        // POST: Actividads/Create
       // para crear una actividad se consultara a  la clace actividadviewmodel con el sin de solo traer una campaña tipo de examen y empresa como un solo objeto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActividadViewModel factividad)
        {
            Actividads actividad = new Actividads();
            if (ModelState.IsValid)
            {
                actividad.IdActividad = factividad.IdActividad;
                actividad.FechaInicial = factividad.FechaInicial;
                actividad.FechaFinal = factividad.FechaInicial;
                actividad.FechaInicialPlan = factividad.FechaInicial;
                actividad.FechaFinalPlan = factividad.FechaInicial;
                actividad.IdActividad = factividad.IdActividad;
                actividad.idtipexam = factividad.idtipexam;
                actividad.Descripcion = factividad.Descripcion;
                actividad.Estado = 0;
                db.Actividads.Add(actividad);
                db.SaveChanges();
                return Json(new { success = true });
            }
            var tipos = new SelectList(db.tipo_examen_ocupacional.ToList(), "idtipexam", "descripcion");
            ViewData["tipos"] = tipos;
            return PartialView(factividad);
        }
       // GET: Actividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividads actividad = db.Actividads.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            //b.Entry(actividad).Reference("tipo_examen_ocupacional").Load();
            ActividadViewModel factividad = new ActividadViewModel();
            factividad.IdActividad = actividad.IdActividad;
            factividad.Descripcion = actividad.Descripcion;
            factividad.FechaInicial = actividad.FechaInicial;
            factividad.IdEmpresa = actividad.Idempresa;
            factividad.idtipexam = actividad.idtipexam;
            factividad.nombre = actividad.tipo_examen_ocupacional.descripcion;
            var tipos = new SelectList(db.tipo_examen_ocupacional.ToList(), "TipoActividadId", "Descripcion");
            ViewData["tipos"] = tipos;
            return PartialView(factividad);
        }

        // POST: Actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       // [Authorize(Roles = "Admin, AdminAgenda")]
        
        //[ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActividadViewModel factividad)
        {
            if (ModelState.IsValid)
            {
                Actividads actividad = db.Actividads.Find(factividad.IdActividad);
                actividad.IdActividad = factividad.IdActividad;
                actividad.FechaInicial = factividad.FechaInicial;
                actividad.FechaFinal = factividad.FechaInicial;
                actividad.FechaInicialPlan = factividad.FechaInicial;
                actividad.FechaFinalPlan = factividad.FechaInicial;
                actividad.Idempresa = factividad.IdEmpresa;
                actividad.idtipexam = factividad.idtipexam;
                actividad.Descripcion = factividad.Descripcion;
                actividad.Estado = 0;
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            var tipos = new SelectList(db.tipo_examen_ocupacional.ToList(), "idtipexam", "Descripcion");
            ViewData["tipos"] = tipos;
            return PartialView(factividad);
        }
       
       
        // GET: Actividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividads actividads = db.Actividads.Find(id);
            if (actividads == null)
            {
                return HttpNotFound();
            }
            return View(actividads);
        }

        // POST: Actividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividads actividads = db.Actividads.Find(id);
            db.Actividads.Remove(actividads);
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
