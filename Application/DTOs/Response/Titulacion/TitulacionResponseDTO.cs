using Application.DTOs.Response.SimpleResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.Titulacion
{
    public class TitulacionResponseDTO
    {
        public int Id { get; set; }
        public string NombreTitulacion { get; set; } = string.Empty;
        public string CodigoTitulacion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public DepartamentoSimpleResponseDTO? Departamento { get; set; }

        public List<PensumSimpleResponseDTO> Pensums { get; set; } = new List<PensumSimpleResponseDTO>();

        public int CantidadEstudiantes { get; set; }
    }
}
