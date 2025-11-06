using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AsignaturaIncompatibilidad
    {
        public int AsignaturaId { get; set; }
        public Asignatura? Asignatura { get; set; }

        public int AsignaturaIncompatibleId { get; set; }
        public Asignatura? AsignaturaIncompatible { get; set; }
    }
}
