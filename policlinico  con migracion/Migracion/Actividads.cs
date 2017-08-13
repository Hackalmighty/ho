namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Actividads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdActividad { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaInicialPlan { get; set; }

        public DateTime FechaFinalPlan { get; set; }

        public int Estado { get; set; }

        public int Idempresa { get; set; }

        public int? IdCampania { get; set; }

        public int idtipexam { get; set; }

        public  empresa empresa { get; set; }

        public  Campanias Campanias { get; set; }

        public  tipo_examen_ocupacional tipo_examen_ocupacional { get; set; }
    }
}
