using Application.DTOs.Response.Horario;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Persona
{
    public class ProfesorResponseDTO : PersonaResponseDTO
    {
        public AreaConocimientoSimpleResponseDTO? AreaConocimiento { get; set; }
        public List<AsignaturaConHorarioResponseDTO> CargaAcademica { get; set; } = new List<AsignaturaConHorarioResponseDTO>();
    }
}
