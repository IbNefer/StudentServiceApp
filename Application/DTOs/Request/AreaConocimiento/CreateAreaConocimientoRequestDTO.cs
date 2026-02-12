using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.AreaConocimiento
{
    public class CreateAreaConocimientoRequestDTO
    {
        [Required]
        public string NombreArea { get; set; } = string.Empty;


        [Required]
        public string CodigoArea { get; set; } = string.Empty;


        [Required]
        public int DepartamentoId { get; set; }
    }
}
