using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.DTOs.Response.SimpleResponseDTO.SimpleResponseDTO;

namespace Application.DTOs.Response.AsignaturaIncompatibilidad
{
    public class AsignaturaIncompatibilidadResponseDTO
    {
       public AsignaturaSimpleResponseDTO Asignatura { get; set; }
       public AsignaturaSimpleResponseDTO AsignaturaIncompatible { get; set; }
    }
}
