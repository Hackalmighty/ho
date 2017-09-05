namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class atencion_admision
    {
        [Key]
        [Column(Order = 0)]
        public int idatencion_admi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_atencion { get; set; }

        [StringLength(100)]
        public string estado { get; set; }

        [StringLength(100)]
        public string tipo_examen { get; set; }

        [StringLength(100)]
        public string local { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtipexam { get; set; }

        public int? idexamenes { get; set; }

        public int? idperfil { get; set; }

        public int? idarea { get; set; }

        public int? Idempresa { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idpersona { get; set; }

        public virtual tipo_examen_ocupacional tipo_examen_ocupacional { get; set; }

        public virtual examenes examenes { get; set; }

        public virtual perfil perfil { get; set; }

        public virtual empresa empresa { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
