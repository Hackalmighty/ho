namespace policlinico__con_migracion.Migracion
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    using TrackerEnabledDbContext.Identity;



        public partial class Model1 : DbContext
    {

        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Actividads> Actividads { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<atencion_admision> atencion_admision { get; set; }
        public virtual DbSet<Campanias> Campanias { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<especialidad> especialidad { get; set; }
        public virtual DbSet<examenes> examenes { get; set; }
        public virtual DbSet<medico> medico { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<perfil> perfil { get; set; }
        public virtual DbSet<tipo_examen_ocupacional> tipo_examen_ocupacional { get; set; }
        public virtual DbSet<detalle_de_perfil> detalle_de_perfil { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<atencion_admision>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<atencion_admision>()
                .Property(e => e.tipo_examen)
                .IsUnicode(false);

            modelBuilder.Entity<atencion_admision>()
                .Property(e => e.local)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.sRazon_social)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.sDireccion)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.sCorreo)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.sContacto_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empresa>()
                .Property(e => e.sContacto_correo)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<especialidad>()
                .HasMany(e => e.perfil)
                .WithRequired(e => e.especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<especialidad>()
                .HasMany(e => e.medico)
                .WithRequired(e => e.especialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<examenes>()
                .Property(e => e.nombre_examen)
                .IsUnicode(false);

            modelBuilder.Entity<examenes>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<examenes>()
                .Property(e => e.recomendaciones)
                .IsUnicode(false);

            modelBuilder.Entity<medico>()
                .Property(e => e.cmp_rne)
                .IsUnicode(false);

            modelBuilder.Entity<medico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<medico>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.num_doc_identidad)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.tipo_doc_identidad)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.lugar_nacimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.grado_instruccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.ocupacion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.estado_ciivil)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Area_de_trabajo)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.atencion_admision)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<perfil>()
                .Property(e => e.nombre_perfil)
                .IsUnicode(false);

            modelBuilder.Entity<perfil>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<perfil>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<perfil>()
                .HasMany(e => e.atencion_admision)
                .WithOptional(e => e.perfil)
                .HasForeignKey(e => new { e.idperfil, e.idarea });

            modelBuilder.Entity<tipo_examen_ocupacional>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_examen_ocupacional>()
                .HasMany(e => e.atencion_admision)
                .WithRequired(e => e.tipo_examen_ocupacional)
                .WillCascadeOnDelete(false);
        }
    }
}
