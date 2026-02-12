using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Pensum
{
    public class PensumResponseDTO
    {
        public int Id { get; set; }
        public string NombrePensum { get; set; } = string.Empty;
        public int Año { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public TitulacionSimpleResponseDTO? Titulacion { get; set; }
        public List<AsignaturaSimpleResponseDTO> Asignaturas { get; set; } = new List<AsignaturaSimpleResponseDTO>();
    }
}
