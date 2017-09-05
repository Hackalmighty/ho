namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class examenes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public examenes()
        {
            atencion_admision = new HashSet<atencion_admision>();
        }

        [Key]
        public int idexamenes { get; set; }

        [StringLength(45)]
        public string nombre_examen { get; set; }

        [StringLength(45)]
        public string costo { get; set; }

        [StringLength(45)]
        public string recomendaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atencion_admision> atencion_admision { get; set; }
    }
}
