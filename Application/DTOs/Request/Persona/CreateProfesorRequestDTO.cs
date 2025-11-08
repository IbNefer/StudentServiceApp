using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Persona
{
    public class CreateProfesorRequestDTO: PersonaDTO
    {
        [Required(ErrorMessage = "El ID del área de conocimiento es obligatorio.")]
        public int AreaConocimientoId { get; set; }
    }
}
