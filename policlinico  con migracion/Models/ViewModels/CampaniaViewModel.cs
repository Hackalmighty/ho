using policlinico__con_migracion.Migracion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace policlinico__con_migracion.Models
{
    public class CampaniaViewModel
    {

        private Model1 contexto;

        public CampaniaViewModel()
        {
            contexto = new Model1();
        }
        public int IdCampania { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public bool Publicada { get; set; }

        public int Idempresa { get; set; }

        public string sRazon_social { get; set; }
        public bool IncluyeProspectos { get; set; }



        public List<ActividadViewModel> GetActividades(int idCampania)
        {
            var consulta = from a in contexto.Actividads
                           join c in contexto.empresa
                           on a.Idempresa equals c.Idempresa
                           join t in contexto.tipo_examen_ocupacional
                           on a.idtipexam equals t.idtipexam
                           where a.Campanias.IdCampania == idCampania
                           select new ActividadViewModel
                           {
                               IdActividad = a.IdActividad,
                               idtipexam = a.idtipexam,
                               nombre = c.sRazon_social,
                               FechaInicial = a.FechaInicial,
                               NombreTipo = t.descripcion
                           };
            return consulta.ToList();
        }

        public bool ExisteCliente(int idCampania, int idempresa)
        {
            var consulta = from a in contexto.Actividads
                           where a.IdCampania == idCampania && a.Idempresa == idempresa
                           select a;
            if (consulta.ToList().Count == 0)
                return false;
            else
                return true;
        }

        public void AgregaCliente(int idCampania, int idempresa)
        {
            Actividads actividad = new Actividads();
            Campanias campania = new Campanias();
            campania = contexto.Campanias.Find(idCampania);
            actividad.Idempresa = idempresa;
            actividad.FechaFinal = campania.Fecha.AddDays(-15);
            actividad.FechaFinalPlan = campania.Fecha.AddDays(-15);
            actividad.FechaInicial = campania.Fecha.AddDays(-15);
            actividad.FechaInicialPlan = campania.Fecha.AddDays(-15);
            actividad.Descripcion = "Llamar por telefono al cliente para la campaña " + campania.Nombre;
            actividad.idtipexam = 6;
            actividad.Estado = 0;
            actividad.IdCampania = campania.IdCampania;
            contexto.Actividads.Add(actividad);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}