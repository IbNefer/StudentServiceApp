using Application.DTOs.Request.Persona;

namespace Application.DTOs.Response.Persona
{
    public class ProfesorResponseDto: CreateProfesorRequestDTO
    {
        public int Id { get; set; }
        public ICollection<ProfesorResponseDto>? Profesores { get; set; }
    }
}