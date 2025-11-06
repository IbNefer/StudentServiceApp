using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AsignaturasPorProfesor
    {
        public int? ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
 
        public int? AsignaturaId { get; set; }
        public Asignatura? Asignatura { get; set; }
    }
}
