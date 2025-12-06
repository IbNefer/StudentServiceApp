using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Horario
{
    public class AsignaturaConHorarioResponseDTO
    {       
        public int Id { get; set; } 
        public string NombreAsignatura { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int Creditos { get; set; }

        public string NombreProfesor { get; set; } = string.Empty;

        public List<string> Horarios { get; set; } = new List<string>();
    }
}
