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
