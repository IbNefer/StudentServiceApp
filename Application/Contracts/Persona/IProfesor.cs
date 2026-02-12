using Application.DTOs.Request.Persona;
using Application.DTOs.Response;
using Application.DTOs.Response.Persona;

namespace Application.Contracts.Persona
{
    public interface IProfesor
    {
        Task<GenericResponse> AddProfesorAsync(CreateProfesorRequestDTO request);
        Task<IEnumerable<ProfesorResponseDTO>> GetProfesoresAsync();
        Task<ProfesorResponseDTO> GetProfesorByIdAsync(int id);
        Task<GenericResponse> UpdateProfesorAsync(CreateProfesorRequestDTO request);
        Task<GenericResponse> DeleteProfesorAsync(int id);
    }
}