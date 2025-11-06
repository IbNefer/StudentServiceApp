using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Creditos { get; set;  }

        public int AreaConocimientoId { get; set; }
        public AreaConocimiento AreaConocimiento { get; set;  }

        public List<Titulacion> Titulaciones { get; set; } = new List<Titulacion>();
        public List<Estudiante> EstudiantesMatriculados { get; set; } = new List<Estudiante>();
    }
}
