using Application.DTOs.Response;
using Application.DTOs.Response.Asignatura;

namespace Application.Contracts.Asignatura
{
    public interface IAsignatura
    {
        Task<GenericResponse> AddAsignatura(AsignaturaResponseDTO model);
        Task<IEnumerable<AsignaturaResponseDTO>> GetAsignaturasAsync();
        Task<AsignaturaResponseDTO> GetAsignaturaByIdAsync(int id);
        Task<GenericResponse> UpdateAsigntura(AsignaturaResponseDTO model);
        Task<GenericResponse>DeleteAsignaturaAsync(int id);
    }
}
