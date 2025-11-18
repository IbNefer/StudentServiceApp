using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AreaConocimiento
    {
        public int Id { get; set; }
        public string NombreArea { get; set; } = string.Empty;
        public string CodigoArea { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public List<Profesor> Profesores { get; set; } = new List<Profesor>();
    }
}
