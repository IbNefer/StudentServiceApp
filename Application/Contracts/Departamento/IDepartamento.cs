using Application.DTOs.Request.Departamento;
using Application.DTOs.Response;
using Application.DTOs.Response.Departamento;

namespace Application.Contracts.Departamento
{
    public interface IDepartamento
    {
        Task<GenericResponse> AddDepartamentoAsync(CreateDepartamentoRequestDTO model);
        Task<IEnumerable<DepartamentoResponseDTO>> GetDepartamentosAsync();
        Task<DepartamentoResponseDTO> GetDepartamentoByIdAsync(int id);
        Task<GenericResponse> UpdateDepartamentoAsync(CreateDepartamentoRequestDTO model);
        Task<GenericResponse> DeleteDepartamentoAsync(int id);
    }
}
