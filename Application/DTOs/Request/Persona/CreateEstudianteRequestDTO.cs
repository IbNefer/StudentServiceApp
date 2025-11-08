using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Persona
{
    public class CreateEstudianteRequestDTO
    {
        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        public int TitulacionId { get; set; }

        public List<int> AsignaturaIds { get; set; } = new List<int>();
    }
}
