using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Asignatura
{
    public class CreateAsignaturasRequestDTO
    {
        [Required]
        public string NombreAsignatura { get; set; } = string.Empty;

        [Required]
        public string CodigoAsignatura { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cantidad de créditos es obligatoria.")]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Creditos { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty; // Ej: "Obligatoria", "Optativa"

        [Required]
        public int AreaConocimientoId { get; set; }
    }
}
