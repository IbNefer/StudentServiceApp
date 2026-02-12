using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AccountService(HttpClientService httpClientService) : IServiceAccount
    {
        public async Task<GenericResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model)
        {
            try
            {
                var pulicClient = await httpClientService.GetPrivateClient();
                var response = await pulicClient.PostAsJsonAsync(Constant.ChangeUserRoleRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag : false, Message : error);
                }
                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag : false, Message : ex.Message);
            }
        }

        public async Task CreateAdmin()
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var admin = new CreateAccountDTO
                {
                    Name = "admin",
                    Password = "Admin123",
                    EmailAdress = "admin@admin.com",
                    Role = Constant.Roles.Admin,
                };
                var response = await publicClient.PostAsJsonAsync(Constant.CreateAdminRoute, admin);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GenericResponse> CreateRoleAsync(CreateRolDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag : false, Message : error);
                }
                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task CreateTokken()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAdminFirstStart()
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsync(Constant.CreateAdminRoute, null);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        public IEnumerable<GetRoleDTO> GetDefaultRoles()
        {
            var roles = new List<GetRoleDTO>();
            roles?.Clear();
            roles?.Add(new GetRoleDTO(1.ToString(), Constant.Roles.Admin));
            roles?.Add(new GetRoleDTO(2.ToString(), Constant.Roles.User));
            return roles!;
        }

        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetRoleDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetUserWithRoleResponseDTO>> GetUserWithRolesAsync()
        {
            try
            { 
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetUserWithRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetUserWithRoleResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<LoginResponse> LoginResponse(LoginDTO model)
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.PostAsJsonAsync(Constant.LoginRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new DTOs.Response.LoginResponse(Flag: false, Message: error);
                }
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new DTOs.Response.LoginResponse(Flag: false, Message: ex.Message);
            }
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RefreshTokenRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new DTOs.Response.LoginResponse(Flag: false, Message: error);
                }
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch
            {
                return new DTOs.Response.LoginResponse(Flag: false, Message: "Sorry unknown error occurred.");
            }
        }

        public async Task<GenericResponse> RegisterAccountAsync(CreateAccountDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag : false, Message : error);
                }
                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return $"Sorry unknown error occurred. Status Code:  {Environment.NewLine}  Error Descripcion: {Environment.NewLine} Status Code: {response.StatusCode}{Environment.NewLine} Reason Phrase: {response.ReasonPhrase}";
            }
            else
                return null;
        }
    }
}
