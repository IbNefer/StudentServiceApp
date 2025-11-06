using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Horario
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
    }
}
