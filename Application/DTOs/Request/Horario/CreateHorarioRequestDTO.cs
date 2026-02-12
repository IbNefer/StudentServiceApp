using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Horario
{
    public class CreateHorarioRequestDTO
    {
        [Required]
        public string DiaSemana { get; set; } = string.Empty;

        [Required]
        public TimeSpan HoraInicio { get; set; } 

        [Required]
        public TimeSpan HoraFin { get; set; } 

        [Required]
        public int AsignaturaId { get; set; }

        [Required]
        public int ProfesorId { get; set; }
    }
}