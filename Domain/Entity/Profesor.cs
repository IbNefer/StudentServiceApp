using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Profesor : Persona
    {
        public int AreaConocimientoId { get; set; }
        public AreaConocimiento? AreaConocimiento { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
