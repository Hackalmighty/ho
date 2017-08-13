using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace policlinico__con_migracion.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

        public string NombreCompleto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizado aquí
           // userIdentity.AddClaim(new Claim("NombreCompleto", this.NombreCompleto));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("policlinico", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       // public DbSet<policlinico__con_migracion.Migracion.AspNetRoles> AspNetRoles { get; set; }
       // public DbSet<policlinico__con_migracion.Migracion.AspNetUserClaims> AspNetUserClaims { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.AspNetUserLogins> AspNetUserLogins { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.AspNetUsers> AspNetUsers { get; set; }
       // public DbSet<policlinico__con_migracion.Migracion.atencion_admision> atencion_admision { get; set; }
       // public DbSet<policlinico__con_migracion.Migracion.C__MigrationHistory> C__MigrationHistory { get; set; }
       // public DbSet<policlinico__con_migracion.Migracion.empresa> empresa { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.especialidad> especialidad { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.examenes> examenes { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.Log> Log { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.log_has_usuario> log_has_usuario { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.medico> medico { get; set; }
          //   public DbSet<policlinico__con_migracion.Migracion.Model1> Model1 { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.paciente> paciente { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.perfil> perfil { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.persona> persona { get; set; }
        //public DbSet<policlinico__con_migracion.Migracion.tipo_examen_ocupacional> tipo_examen_ocupacional { get; set; }
     //   public DbSet<policlinico__con_migracion.Migracion.usuario_has_atencion> usuario_has_atencion { get; set; }
      

     

    }
}