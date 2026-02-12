using Application.Contracts.Account;
using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount account) : ControllerBase
    {
        [HttpPost("identity/create")]
        public async Task<ActionResult<GenericResponse>> CreateAccount(CreateAccountDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model cannot be null");
            }
            return Ok(await account.CreateAccountAsync(model));
        }

        [HttpPost("identity/login")]
        public async Task<ActionResult<GenericResponse>> LoginAccount(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model cannot be null");
            }
            return Ok(await account.LoginAccountAsync(model));
        }

        [HttpPost("identity/refresh-token")]
        public async Task<ActionResult<GenericResponse>> RefreshToken(RefreshTokenDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model cannot be null");
            }
            return Ok(await account.RefreshTokenAsync(model));
        }

        [HttpPost("identity/role/create")]
        public async Task<ActionResult<GenericResponse>> CreateRole(CreateRolDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model cannot be null");
            }
            return Ok(await account.CreateRoleAsync(model));
        }

        [HttpGet("identity/roles/list")]
        public async Task<ActionResult<IEnumerable<GetRoleDTO>>> GetRoles()
        {
            return Ok(await account.GetRolesAsync());
        }

        [HttpPost("/setting")]
        public async Task<ActionResult<GenericResponse>> CreateAdminAccount()
        {
            return Ok(await account.CreateAdmin());
        }

        [HttpGet("identity/users-with-roles")]
        public async Task<ActionResult<IEnumerable<GetUserWithRoleResponseDTO>>> GetUsersWithRoles()
        {
            return Ok(await account.GetUserWithRolesAsync());
        }

        [HttpPost("identity/change-role")]
        public async Task<ActionResult<GenericResponse>> ChangeUserRole(ChangeUserRoleRequestDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model cannot be null");
            }
            return Ok(await account.ChangeUserRole(model));
        }
    }
}