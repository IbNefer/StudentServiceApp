using Application.Contracts.Asignatura;
using Application.DTOs.Request.Asignatura; // Importante para el CreateAsignaturaRequestDTO
using Application.DTOs.Response;
using Application.DTOs.Response.Asignatura;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AsignaturaService(HttpClientService httpClientService) : IAsignaturaService
    {
        // Asegúrate de que esta constante exista en tu clase Constant
        private const string Route = Constant.AsignaturaRoute;

        // ---------------------------------------------------------
        // 1. CREATE (POST) - Usando RequestDTO
        // ---------------------------------------------------------
        public async Task<GenericResponse> AddAsignatura(CreateAsignaturasRequestDTO model)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PostAsJsonAsync(Route, model);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 2. UPDATE (PUT) - Usando RequestDTO
        // ---------------------------------------------------------
        public async Task<GenericResponse> UpdateAsigntura(CreateAsignaturasRequestDTO model)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PutAsJsonAsync(Route, model);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 3. DELETE (DELETE)
        // ---------------------------------------------------------
        public async Task<GenericResponse> DeleteAsignaturaAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.DeleteAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    return new GenericResponse(Flag: false, Message: error);
                }

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex)
            {
                return new GenericResponse(Flag: false, Message: ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 4. GET BY ID (GET)
        // ---------------------------------------------------------
        public async Task<AsignaturaResponseDTO> GetAsignaturaByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                return (await response.Content.ReadFromJsonAsync<AsignaturaResponseDTO>())!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 5. GET ALL (GET)
        // ---------------------------------------------------------
        public async Task<IEnumerable<AsignaturaResponseDTO>> GetAsignaturasAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaResponseDTO>>())!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // HELPER
        // ---------------------------------------------------------
        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode
                ? null
                : $"Error: {response.StatusCode}, {response.ReasonPhrase}";
        }
    }
}