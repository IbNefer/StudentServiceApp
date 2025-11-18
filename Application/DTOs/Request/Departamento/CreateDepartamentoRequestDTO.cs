using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Departamento
{
    public class CreateDepartamentoRequestDTO
    {
        [Required]
        public string NombreDepartamento { get; set; } = string.Empty;

        [Required]
        public string CodigoDepartamento { get; set; } = string.Empty;
    }
}
