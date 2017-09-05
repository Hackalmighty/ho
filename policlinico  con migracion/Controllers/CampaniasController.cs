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
// creada por hilton 
//controlador de campañas  para  usar el  crud  de la identidad campañas.

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
            CampaniaViewModel campania = new CampaniaViewModel();
            return PartialView(campania);
        }

        // POST: Campanias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCampania,Nombre,Fecha,IncluyeProspectos")] CampaniaViewModel campanias)
        {
            if (ModelState.IsValid)
            {
                Campanias campania = new Campanias();
                campania.Nombre = campanias.Nombre;
                campania.Fecha = campanias.Fecha;
                campania.FechaPlan = campanias.Fecha;
                campania.Publicada = false;
                if (campanias.IncluyeProspectos)
                {
                    var prospectos = (from c in db.empresa
                                       select c).ToList();
                    foreach (var item in prospectos)
                    {
                        campania.Actividads.Add(new Actividads
                        {
                            Idempresa = item.Idempresa,
                            FechaFinal = campania.Fecha.AddDays(-15),
                            FechaFinalPlan = campania.Fecha.AddDays(-15),
                            FechaInicial = campania.Fecha.AddDays(-15),
                            FechaInicialPlan = campania.Fecha.AddDays(-15),
                            Descripcion = "Llamar por telefono la empresa para la campaña " + campania.Nombre,
                            idtipexam = 6,
                            Estado = 0
                        });
                    }
                }
                db.Campanias.Add(campania);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView(campanias);
        }
    

        // GET: Campanias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campanias campania = db.Campanias.Find(id);
            if (campania == null)
            {
                return HttpNotFound();
            }
            CampaniaViewModel fcampania = new CampaniaViewModel();
            fcampania.IdCampania = campania.IdCampania;
            fcampania.Fecha = campania.Fecha;
            fcampania.Nombre = campania.Nombre;
            fcampania.Publicada = campania.Publicada;
            return View(fcampania);
        }

        // POST: Campanias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCampania,Nombre,FechaPlan,Fecha,")] Campanias campanias)
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
        public ActionResult MuestraDetalle(int idCampania)
        {
            CampaniaViewModel campania = new CampaniaViewModel();
            List<ActividadViewModel> actividades = campania.GetActividades(idCampania);
            campania.Dispose();
            return PartialView("_ListadoActividades", actividades);
        }

        public ActionResult AgregaActividad(int idCampania, int idCliente)
        {
            CampaniaViewModel fcampania = new CampaniaViewModel();
            if (!fcampania.ExisteCliente(idCampania, idCliente))
                fcampania.AgregaCliente(idCampania, idCliente);
            List<ActividadViewModel> actividades = new List<ActividadViewModel>();
            actividades = fcampania.GetActividades(idCampania);
            fcampania.Dispose();
            return PartialView("_ListadoActividades", actividades);
        }
        public ActionResult EliminaActividad(int idActividad)
        {
            Actividads actividad = db.Actividads.Find(idActividad);
            if (actividad != null)
            {
                int idCampania = (int)actividad.IdCampania;
                db.Actividads.Remove(actividad);
                db.SaveChanges();
                Campanias campania = db.Campanias.Find(idCampania);
                CampaniaViewModel fcampania = new CampaniaViewModel();
                fcampania.IdCampania = campania.IdCampania;
                fcampania.Fecha = campania.Fecha;
                fcampania.Nombre = campania.Nombre;
                return View("Edit", fcampania);
            }
            else
                return HttpNotFound();
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
