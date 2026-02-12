using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IServiceAccount
    {
        Task CreateTokken();
        Task CreateAdmin();
        Task<GenericResponse> RegisterAccountAsync(CreateAccountDTO model);
        Task<LoginResponse> LoginResponse(LoginDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<GenericResponse> CreateRoleAsync(CreateRolDTO model);
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();
        IEnumerable<GetRoleDTO> GetDefaultRoles();

        Task<IEnumerable<GetUserWithRoleResponseDTO>> GetUserWithRolesAsync();
        Task<GenericResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model);
    }
}
