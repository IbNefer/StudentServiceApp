using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.AreaConocimiento
{
    public class AreaConocimientoResponseDTO
    {
        public int Id { get; set; }
        public string NombreAreaConocimiento { get; set; } = string.Empty;
        public string CodigoAreaConocimiento { get; set; } = string.Empty;

        public List<AsignaturaSimpleResponseDTO> Asignaturas { get; set; } = new List<AsignaturaSimpleResponseDTO>();

        public List<ProfesorSimpleResponseDTO> Profesores { get; set; } = new List<ProfesorSimpleResponseDTO>();
    }
}
