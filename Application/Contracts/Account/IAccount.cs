using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;

namespace Application.Contracts.Account
{
    public interface IAccount
    {
        Task CreateTokken();
        Task<GenericResponse> CreateAccountAsync(CreateAccountDTO model);
        Task<LoginResponse> LoginResponse(LoginDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<GenericResponse> CreateRoleAsync(CreateRolDTO model);
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();
        Task<IEnumerable<GetUserWithRoleResponseDTO>> GetUserWithRolesAsync();
        Task<GenericResponse> ChangeUserRole(ChangeUserRoleRequestDTO model);
        Task<GenericResponse> LoginAccountAsync(LoginDTO model);
        Task<GenericResponse> CreateAdmin();
    }
}
