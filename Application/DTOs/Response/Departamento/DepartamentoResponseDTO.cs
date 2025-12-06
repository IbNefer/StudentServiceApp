
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Departamento
{
    public class DepartamentoResponseDTO
    {
        public int Id { get; set; }
        public string NombreDepartamento { get; set; } = string.Empty;
        public string CodigoDepartamento { get; set; } = string.Empty;

        public List<TitulacionSimpleResponseDTO> Titulaciones { get; set; } = new List<TitulacionSimpleResponseDTO>();
        public List<AreaConocimientoSimpleResponseDTO> AreasConocimiento { get; set; } = new List<AreaConocimientoSimpleResponseDTO>();
        public List<ProfesorSimpleResponseDTO> Profesores { get; set; } = new List<ProfesorSimpleResponseDTO>();
    }
}
