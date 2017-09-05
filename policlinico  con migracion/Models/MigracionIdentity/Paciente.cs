namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            atencion_admision = new HashSet<atencion_admision>();
        }

        [Key]
        public int idpersona { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellido { get; set; }

        [StringLength(45)]
        public string num_doc_identidad { get; set; }

        [StringLength(45)]
        public string tipo_doc_identidad { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        [StringLength(45)]
        public string telefono { get; set; }

        [StringLength(45)]
        public string celular { get; set; }

        [StringLength(45)]
        public string lugar_nacimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_nacimiento { get; set; }

        [StringLength(45)]
        public string grado_instruccion { get; set; }

        [StringLength(45)]
        public string ocupacion { get; set; }

        [StringLength(45)]
        public string estado_ciivil { get; set; }

        [StringLength(45)]
        public string Area_de_trabajo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atencion_admision> atencion_admision { get; set; }
    }
}
