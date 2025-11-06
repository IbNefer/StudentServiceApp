using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Titulacion
    {
        public int Id { get; set; }
        public string NombreTitulacion { get; set; } = string.Empty;
        public string CodigoTitulacion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
