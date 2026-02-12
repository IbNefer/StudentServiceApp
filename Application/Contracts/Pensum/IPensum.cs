using Application.DTOs.Request.Pensum;
using Application.DTOs.Response;
using Application.DTOs.Response.Pensum;

namespace Application.Contracts.Pensum
{
    public interface IPensum
    {
        Task<GenericResponse> AddPensumAsync(CreatePensumRequestDTO model);
        Task<IEnumerable<PensumResponseDTO>> GetPensumsAsync();
        Task<PensumResponseDTO> GetPensumByIdAsync(int id);
        Task<GenericResponse> UpdatePensumAsync(CreatePensumRequestDTO model);
        Task<GenericResponse> DeletePensumAsync(int id);
    }
}
