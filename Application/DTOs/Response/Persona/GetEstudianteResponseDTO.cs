using Application.DTOs.Response.Horario;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Persona
{
    public class EstudianteResponseDTO : PersonaResponseDTO
    {
        public string NumeroMatricula { get; set; } = string.Empty;

        public TitulacionSimpleResponseDTO? Titulacion { get; set; }

        public List<AsignaturaConHorarioResponseDTO> AsignaturasInscritas { get; set; } = new List<AsignaturaConHorarioResponseDTO>();
    }
}
