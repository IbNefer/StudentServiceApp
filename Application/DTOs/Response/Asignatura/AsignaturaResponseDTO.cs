using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Asignatura
{
    public class AsignaturaResponseDTO
    {
        public int Id { get; set; }
        public string NombreAsignatura { get; set; } = string.Empty;
        public string CodigoAsignatura { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public string Tipo { get; set; } = string.Empty;

        public AreaConocimientoSimpleResponseDTO? AreaConocimiento { get; set; }

        public List<TitulacionSimpleResponseDTO> Titulaciones { get; set; } = new List<TitulacionSimpleResponseDTO>();

        public List<HorarioConProfesorDTO> HorariosDisponibles { get; set; } = new List<HorarioConProfesorDTO>();
    }
}
