using Application.Contracts.Persona;
using Application.DTOs.Request.Persona;
using Application.DTOs.Response;
using Application.DTOs.Response.Persona;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class ProfesorService(HttpClientService httpClientService) : IProfesorService
    {
        // ---------------------------------------------------------
        // 1. CREATE (POST)
        // ---------------------------------------------------------
        public async Task<GenericResponse> AddProfesorAsync(CreateProfesorRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PostAsJsonAsync(Constant.ProfesorRoute, request);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 2. READ ALL (GET)
        // ---------------------------------------------------------
        public async Task<IEnumerable<ProfesorResponseDTO>> GetProfesoresAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Constant.ProfesorRoute);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<ProfesorResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 3. READ BY ID (GET)
        // ---------------------------------------------------------
        public async Task<ProfesorResponseDTO> GetProfesorByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta ejemplo: api/profesor/5
                var response = await client.GetAsync($"{Constant.ProfesorRoute}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<ProfesorResponseDTO>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 4. UPDATE (PUT)
        // ---------------------------------------------------------
        public async Task<GenericResponse> UpdateProfesorAsync(CreateProfesorRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();

               
                var response = await client.PutAsJsonAsync(Constant.ProfesorRoute, request);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 5. DELETE (DELETE)
        // ---------------------------------------------------------
        public async Task<GenericResponse> DeleteProfesorAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta ejemplo: api/profesor/5
                var response = await client.DeleteAsync($"{Constant.ProfesorRoute}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                var result = await response.Content.ReadFromJsonAsync<GenericResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // HELPER
        // ---------------------------------------------------------
        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return $"Error: {response.StatusCode}, {response.ReasonPhrase}";
            }
            return null;
        }
    }
}