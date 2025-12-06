using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.AsignaturaEquivalencia
{
    public class AsignaturaEquivalenciaResponseDTO
    {
        public AsignaturaSimpleResponseDTO Asignatura { get; set; }
        public AsignaturaSimpleResponseDTO AsignaturaEquivalente { get; set; }
    }
}
