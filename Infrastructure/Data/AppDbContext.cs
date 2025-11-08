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
                .HasOne(t => t.Departamento) 
                .WithMany(d => d.Titulaciones) 
                .HasForeignKey(t => t.DepartamentoId) 
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<AreaConocimiento>()
                .HasOne(a => a.Departamento)
                .WithMany(d => d.AreasConocimiento) 
                .HasForeignKey(a => a.DepartamentoId) 
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<AsignaturaEquivalencia>()
                .HasOne(ae => ae.Asignatura)
                .WithMany() 
                .HasForeignKey(ae => ae.AsignaturaId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AsignaturaEquivalencia>()
                .HasOne(ae => ae.AsignaturaEquivalente)
                .WithMany() 
                .HasForeignKey(ae => ae.AsignaturaEquivalenteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AsignaturaIncompatibilidad>()
                .HasOne(ai => ai.Asignatura)
                .WithMany() 
                .HasForeignKey(ai => ai.AsignaturaId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AsignaturaIncompatibilidad>()
                .HasOne(ai => ai.AsignaturaIncompatible) 
                .WithMany()
                .HasForeignKey(ai => ai.AsignaturaIncompatibleId)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.AreaConocimiento)
                .WithMany(a => a.Profesores)
                .HasForeignKey(p => p.AreaConocimientoId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<Asignatura>()
                .HasOne(a => a.AreaConocimiento)
                .WithMany() 
                .HasForeignKey(a => a.AreaConocimientoId)
                .OnDelete(DeleteBehavior.Restrict); 

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
