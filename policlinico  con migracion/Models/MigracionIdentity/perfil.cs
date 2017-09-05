namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("perfil")]
    public partial class perfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perfil()
        {
            atencion_admision = new HashSet<atencion_admision>();
        }

        [Key]
        [Column(Order = 0)]
        public int idperfil { get; set; }

        [Column("nombre perfil")]
        [StringLength(45)]
        public string nombre_perfil { get; set; }

        [StringLength(45)]
        public string costo { get; set; }

        [StringLength(45)]
        public string estado { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idespecialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atencion_admision> atencion_admision { get; set; }

        public virtual especialidad especialidad { get; set; }
    }
}
