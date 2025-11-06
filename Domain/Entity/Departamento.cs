using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Departamento
    {
        public int Id { get; set; }
        public string NombreDepartamento { get; set; } = string.Empty;
        public string CodigoDepartamento { get; set; } = string.Empty;


        public int PensumId { get; set; }
        public Pensum? Pensum { get; set; }

        public List<Profesor> Profesores { get; set; } = new List<Profesor>();
        public List<AreaConocimiento> AreasConocimiento { get; set; } = new List<AreaConocimiento>();
    }
}
