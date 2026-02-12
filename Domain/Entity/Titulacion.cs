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

        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }

        public List<Pensum> Pensums { get; set; } = new List<Pensum>();

        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
