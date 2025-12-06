
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.AsignaturaIncompatibilidad
{
    public class AsignaturaIncompatibilidadRequestDTO
    {
        [Required]
        public int AsignaturaId { get; set; } 
        [Required]
        public int AsignaturaIncompatibleId { get; set; }
    }
}
