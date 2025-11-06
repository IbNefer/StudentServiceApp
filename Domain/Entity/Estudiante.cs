using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Estudiante : Persona
    {
        public string Matricula { get; set; } = string.Empty;

        public int? TitulacionId { get; set; } 
        public Titulacion? Titulacion { get; set; }

        public List<Asignatura> AsignaturasMatriculadas { get; set; } = new List<Asignatura>();
    }
}
