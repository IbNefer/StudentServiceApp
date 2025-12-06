using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.AsignaturasEquivalencia
{
    public class AsignaturaEquivalenciaRequestDTO
    {
        [Required]
        public int AsignaturaId { get; set; } 

        [Required]
        public int AsignaturaEquivalenteId { get; set; }
    }
}
