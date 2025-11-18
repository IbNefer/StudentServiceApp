using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Entity
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string NombreAsignatura { get; set; } = string.Empty;
        public string CodigoAsignatura { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public string Tipo { get; set; } = string.Empty;


        public int AreaConocimientoId { get; set; }
        public AreaConocimiento? AreaConocimiento { get; set; }

        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
