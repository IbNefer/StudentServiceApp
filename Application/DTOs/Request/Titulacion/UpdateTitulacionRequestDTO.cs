using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Titulacion
{
    public class UpdateTitulacionRequestDTO: CreateTitulacionRequestDTO
    {
        public int Id { get; set; }
    }
}
