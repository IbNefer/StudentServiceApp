using Application.DTOs.Request.Horario;
using Application.DTOs.Response;
using Application.DTOs.Response.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Horario
{
    public interface IHorario
    {
        Task<GenericResponse> AddHorarioAsync(CreateHorarioRequestDTO model);
        Task<IEnumerable<AsignaturaConHorarioResponseDTO>> GetHorariosAsync();
        Task<AsignaturaConHorarioResponseDTO> GetHorarioByIdAsync(int id);
        Task<GenericResponse> UpdateHorarioAsync(CreateHorarioRequestDTO model);
        Task<GenericResponse> DeleteHorarioAsync(int id);
    }
}
