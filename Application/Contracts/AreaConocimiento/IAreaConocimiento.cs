using Application.DTOs.Request.AreaConocimiento;
using Application.DTOs.Response;
using Application.DTOs.Response.AreaConocimiento;

namespace Application.Contracts.AreaConocimiento
{
    public interface IAreaConocimiento
    {
        Task<GenericResponse> AddAreaConocimientoAsync(CreateAreaConocimientoRequestDTO model);
        Task<IEnumerable<AreaConocimientoResponseDTO>> GetAreasConocimientoAsync();
        Task<AreaConocimientoResponseDTO> GetAreaConocimientoByIdAsync(int id);
        Task<GenericResponse> UpdateAreaConocimientoAsync(CreateAreaConocimientoRequestDTO model);
        Task<GenericResponse> DeleteAreaConocimientoAsync(int id);
    }
}
