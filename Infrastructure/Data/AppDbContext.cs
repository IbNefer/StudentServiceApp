using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AsignaturasPorProfesor>()
                .HasKey(ap => new { ap.ProfesorId, ap.AsignaturaId });

            modelBuilder.Entity<AsignaturaEquivalencia>()
                .HasKey(ae => new { ae.AsignaturaId, ae.AsignaturaEquivalenteId });

            modelBuilder.Entity<AsignaturaIncompatibilidad>()
                .HasKey(ae => new { ae.AsignaturaId, ae.AsignaturaIncompatibleId});


            modelBuilder.Entity<Titulacion>()
                .HasOne(t => t.Departamento) // La Titulacion tiene un Departamento
                .WithMany(d => d.Titulaciones) // El Departamento tiene muchas Titulaciones
                .HasForeignKey(t => t.DepartamentoId) // La clave foránea
                .OnDelete(DeleteBehavior.Restrict); // ¡ESTA ES LA SOLUCIÓN!

            // 2. Configura la relación Departamento -> AreaConocimiento
            // Le decimos que NO borre en cascada
            modelBuilder.Entity<AreaConocimiento>()
                .HasOne(a => a.Departamento) // El Area tiene un Departamento
                .WithMany(d => d.AreasConocimiento) // El Depto. tiene muchas Areas
                .HasForeignKey(a => a.DepartamentoId) // La clave foránea
                .OnDelete(DeleteBehavior.Restrict); // ¡ESTA ES LA SOLUCIÓN!

            // 1. Para AsignaturaEquivalencia
            modelBuilder.Entity<AsignaturaEquivalencia>()
                .HasOne(ae => ae.Asignatura)
                .WithMany() // Asumimos que Asignatura no tiene una lista de "Equivalencias"
                .HasForeignKey(ae => ae.AsignaturaId)
                .OnDelete(DeleteBehavior.Restrict); // <-- SOLUCIÓN

            modelBuilder.Entity<AsignaturaEquivalencia>()
                .HasOne(ae => ae.AsignaturaEquivalente)
                .WithMany() // Asumimos que Asignatura no tiene una lista de "Equivalentes"
                .HasForeignKey(ae => ae.AsignaturaEquivalenteId)
                .OnDelete(DeleteBehavior.Restrict); // <-- SOLUCIÓN

            // 2. Para AsignaturaIncompatibilidad
            modelBuilder.Entity<AsignaturaIncompatibilidad>()
                .HasOne(ai => ai.Asignatura)
                .WithMany() // Asumimos que no hay lista de vuelta
                .HasForeignKey(ai => ai.AsignaturaId)
                .OnDelete(DeleteBehavior.Restrict); // <-- SOLUCIÓN

            modelBuilder.Entity<AsignaturaIncompatibilidad>()
                .HasOne(ai => ai.AsignaturaIncompatible) // Asumo que tu propiedad se llama así
                .WithMany() // Asumimos que no hay lista de vuelta
                .HasForeignKey(ai => ai.AsignaturaIncompatibleId)
                .OnDelete(DeleteBehavior.Restrict); // <-- SOLUCIÓN

            // 1. Rompe el ciclo AreaConocimiento -> Profesor
            // (Asumo que tu AreaConocimiento tiene List<Profesor> Profesores)
            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.AreaConocimiento)
                .WithMany(a => a.Profesores) // <-- Nombre de la lista en AreaConocimiento
                .HasForeignKey(p => p.AreaConocimientoId)
                .OnDelete(DeleteBehavior.Restrict); // ¡SOLUCIÓN!

            // 2. Rompe el ciclo AreaConocimiento -> Asignatura
            // (Asumo que Asignatura tiene AreaConocimientoId, pero
            // AreaConocimiento no tiene List<Asignatura>)
            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.AreaConocimiento)
                .WithMany() // <-- Vacío si no hay lista en AreaConocimiento
                .HasForeignKey(a => a.AreaConocimientoId)
                .OnDelete(DeleteBehavior.Restrict); // ¡SOLUCIÓN!

        }


        public DbSet<Materia> Materias { get; set; }
        public DbSet<Pensum> Pensums { get; set; }
        public DbSet<AsignaturasPorProfesor> AsignaturasPorProfesores { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Titulacion> Titulaciones { get; set; }
        public DbSet<AreaConocimiento> AreasConocimiento { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DisponibilidadProfesor> DisponibilidadProfesores { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<AsignaturaEquivalencia> AsignaturaEquivalencias { get; set; }
        public DbSet<AsignaturaIncompatibilidad> AsignaturaIncompatibilidades { get; set; }
    }
}
