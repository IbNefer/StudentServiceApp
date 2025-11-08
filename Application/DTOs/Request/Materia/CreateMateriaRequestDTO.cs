using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Materia
{
    public class CreateMateriaRequestDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cantidad de créditos es obligatoria.")]
        public int Creditos { get; set; }

        [Required]
        public int AreaConocimientoId { get; set; }
    }
}
