using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Persona
{
    public class PersonaDTO
    {
        [Required]
        public string DniId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }
    }
}
