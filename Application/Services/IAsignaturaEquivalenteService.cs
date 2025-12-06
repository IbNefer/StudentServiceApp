using Application.DTOs.Request.AsignaturasEquivalencia;
using Application.DTOs.Response;
using Application.DTOs.Response.AsignaturaEquivalencia;

namespace Application.Contracts.AsignaturaEquivalencia
{
    public interface IAsignaturaEquivalenciaService
    {
        Task<GenericResponse> AddAsignaturaEquivalenciaAsync(AsignaturaEquivalenciaRequestDTO model);
        Task<GenericResponse> DeleteAsignaturaEquivalenciaAsync(int asignaturaId, int asignaturaEquivalenteId);
        Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetAsignaturasEquivalenciasAsync();
        Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetEquivalenciasByAsignaturaIdAsync(int asignaturaId);
        Task<bool> AsignaturaEquivalenciaExistsAsync(int asignaturaId, int asignaturaEquivalenteId);
        Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetEquivalenciasByAsignaturaEquivalenteIdAsync(int asignaturaEquivalenteId);
    }
}