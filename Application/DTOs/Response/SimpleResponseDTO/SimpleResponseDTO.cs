using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.SimpleResponseDTO
{
    public class SimpleResponseDTO
    {
        public class DepartamentoSimpleResponseDTO
        {
            public int Id { get; set; }
            public string NombreDepartamento { get; set; } = string.Empty;
            public string CodigoDepartamento { get; set; } = string.Empty;
        }

        public class ProfesorSimpleResponseDTO
        {
            public int Id { get; set; }

            public string DniId { get; set; } = string.Empty;

            public string NombreCompleto { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;
        }

        public class TitulacionSimpleResponseDTO
        {
            public int Id { get; set; }
            public string NombreTitulacion { get; set; } = string.Empty;
            public string CodigoTitulacion { get; set; } = string.Empty;
            public string Tipo { get; set; } = string.Empty;
        }

        public class AreaConocimientoSimpleResponseDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public class PensumSimpleResponseDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }

        public class AsignaturaSimpleResponseDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Codigo { get; set; } = string.Empty;
            public int Creditos { get; set; }
        }

        public class HorarioConProfesorDTO
        {
            public string Dia { get; set; } = string.Empty;
            public string HoraInicio { get; set; } = string.Empty; 
            public string HoraFin { get; set; } = string.Empty;    
            public string NombreProfesor { get; set; } = string.Empty;
        }
    }
}
