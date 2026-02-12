using Application.DTOs.Request.Horario;
using Application.DTOs.Response;
using Application.DTOs.Response.Horario;

namespace Application.Contracts.Horario
{
    public interface IHorarioService
    {
        Task<GenericResponse> AddHorarioAsync(CreateHorarioRequestDTO model);
        Task<IEnumerable<AsignaturaConHorarioResponseDTO>> GetHorariosAsync();
        Task<AsignaturaConHorarioResponseDTO> GetHorarioByIdAsync(int id);
        Task<GenericResponse> UpdateHorarioAsync(CreateHorarioRequestDTO model);
        Task<GenericResponse> DeleteHorarioAsync(int id);
    }
}
