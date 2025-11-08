using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Pensum
{
    public class CreatePensumRequestDTO
    {
        [Required]
        public int Año { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public int TitulacionId { get; set; }
    }
}
