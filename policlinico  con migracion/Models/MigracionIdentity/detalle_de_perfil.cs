namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class detalle_de_perfil
    {
        public DateTime? fechacreacion { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDetalleperfil { get; set; }

        public int? idperfil { get; set; }

        public int? idespecialidad { get; set; }

        public int? idexamenes { get; set; }
    }
}
