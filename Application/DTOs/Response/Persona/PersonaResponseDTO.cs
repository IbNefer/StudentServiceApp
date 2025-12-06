using Application.DTOs.Request.Persona;

namespace Application.DTOs.Response.Persona
{
    public class PersonaResponseDTO
    {
        public int Id { get; set; }
        public string DniId { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}