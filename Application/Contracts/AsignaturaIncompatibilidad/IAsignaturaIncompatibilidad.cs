using Application.DTOs.Request.AsignaturaIncompatibilidad;
using Application.DTOs.Response;
using Application.DTOs.Response.AsignaturaIncompatibilidad;

namespace Application.Contracts.AsignaturaIncompatibilidad
{
    public interface IAsignaturaIncompatibilidad
    {
        Task<GenericResponse> AddAsignaturaIncompatibilidadAsync(AsignaturaIncompatibilidadRequestDTO model);
        Task<GenericResponse> DeleteAsignaturaIncompatibilidadAsync(int asignaturaId, int asignaturaIncompatibleId);
        Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetAsignaturasIncompatibilidadsAsync();
        Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetIncompatibilidadsByAsignaturaIdAsync(int asignaturaId);
        Task<bool> AsignaturaIncompatibilidadExistsAsync(int asignaturaId, int asignaturaIncompatibleId);
        Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetIncompatibilidadsByAsignaturaIncompatibleIdAsync(int asignaturaIncompatibleId);
    }
}