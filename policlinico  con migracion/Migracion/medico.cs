namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("medico")]
    public partial class medico
    {
        [Key]
        [Column(Order = 0)]
        public int idmedico { get; set; }

        [StringLength(45)]
        public string cmp_rne { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_alta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_baja { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idpersona { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idespecialidad { get; set; }

        public virtual especialidad especialidad { get; set; }

        public virtual persona persona { get; set; }
    }
}
