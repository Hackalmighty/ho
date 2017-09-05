namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("empresa")]
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            Actividads = new HashSet<Actividads>();
            atencion_admision = new HashSet<atencion_admision>();
        }

        [Key]
        public int Idempresa { get; set; }

        [StringLength(100)]
        public string sRazon_social { get; set; }

        [StringLength(100)]
        public string sDireccion { get; set; }

        public int? iTelefono { get; set; }

        public int? iRuc { get; set; }

        public int? iCelular { get; set; }

        [StringLength(45)]
        public string sCorreo { get; set; }

        [StringLength(45)]
        public string sContacto_nombre { get; set; }

        public int? iContacto_celular { get; set; }

        [StringLength(45)]
        public string sContacto_correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividads> Actividads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atencion_admision> atencion_admision { get; set; }
    }
}
