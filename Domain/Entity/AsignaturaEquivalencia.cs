using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AsignaturaEquivalencia
    {
        
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

     
        public int AsignaturaEquivalenteId { get; set; }
        public Asignatura AsignaturaEquivalente { get; set; }
    }
}
