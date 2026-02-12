using Application.DTOs.Request.Asignatura;
using Application.DTOs.Response;
using Application.DTOs.Response.Asignatura;

namespace Application.Contracts.Asignatura
{
    public interface IAsignaturaService
    {
        // En IAsignaturaService.cs
        Task<GenericResponse> AddAsignatura(CreateAsignaturasRequestDTO model); 
        Task<GenericResponse> UpdateAsigntura(CreateAsignaturasRequestDTO model); // Antes decía AsignaturaResponseDTO
        Task<IEnumerable<AsignaturaResponseDTO>> GetAsignaturasAsync();
        Task<AsignaturaResponseDTO> GetAsignaturaByIdAsync(int id);
        Task<GenericResponse> DeleteAsignaturaAsync(int id);
    }
}
