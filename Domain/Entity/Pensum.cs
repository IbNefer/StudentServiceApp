using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pensum
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int TitulacionId { get; set; }
        public Titulacion? Titulacion { get; set; }


        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    }
}
