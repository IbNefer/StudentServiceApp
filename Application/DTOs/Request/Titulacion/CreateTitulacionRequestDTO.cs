using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Titulacion
{
    public class CreateTitulacionRequestDTO
    {
        public string NombreTitulacion { get; set; } = string.Empty;

        public string CodigoTitulacion { get; set; } = string.Empty; 

        public string Tipo { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }
    }
}
