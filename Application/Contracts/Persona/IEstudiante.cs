using Application.DTOs.Request.Persona;
using Application.DTOs.Response; 
using Application.DTOs.Response.Persona;

namespace Application.Contracts.Persona
{
    public interface IEstudiante
    {
        Task<GenericResponse> AddEstudianteAsync(CreateEstudianteRequestDTO request);
        Task<IEnumerable<EstudianteResponseDTO>> GetEstudiantesAsync();
        Task<EstudianteResponseDTO> GetEstudianteByIdAsync(int id);

        Task<GenericResponse> UpdateEstudianteAsync(CreateEstudianteRequestDTO request);
        Task<GenericResponse> DeleteEstudianteAsync(int id);
    }
}