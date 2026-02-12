using Application.DTOs.Request.Titulacion;
using Application.DTOs.Response;
using Application.DTOs.Response.Titulacion;

namespace Application.Services
{
    public interface ITitulacionService
    {

        Task<GenericResponse> AddTitulacionAsync(CreateTitulacionRequestDTO request);


        Task<IEnumerable<TitulacionResponseDTO>> GetTitulacionesAsync();

        Task<TitulacionResponseDTO> GetTitulacionByIdAsync(int id);


        Task<GenericResponse> UpdateTitulacionAsync(int id, CreateTitulacionRequestDTO request);


        Task<GenericResponse> DeleteTitulacionAsync(int id);


        Task<IEnumerable<TitulacionResponseDTO>> GetTitulacionesByDepartamentoIdAsync(int departamentoId);
    }
}