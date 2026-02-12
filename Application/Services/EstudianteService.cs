using Application.DTOs.Request.Persona;
using Application.DTOs.Response;
using Application.DTOs.Response.Persona;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class EstudianteService(HttpClientService httpClientService) : IEstudianteService
    {
        // ---------------------------------------------------------
        // 1. CREATE (POST)
        // ---------------------------------------------------------
        public async Task<GenericResponse> AddEstudianteAsync(CreateEstudianteRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PostAsJsonAsync(Constant.EstudianteRoute, request);

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
        // 2. DELETE (DELETE)
        // ---------------------------------------------------------
        public async Task<GenericResponse> DeleteEstudianteAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta: api/estudiante/5
                var response = await client.DeleteAsync($"{Constant.EstudianteRoute}/{id}");

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
        // 3. GET BY ID (GET)
        // ---------------------------------------------------------
        public async Task<EstudianteResponseDTO> GetEstudianteByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta: api/estudiante/5
                var response = await client.GetAsync($"{Constant.EstudianteRoute}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<EstudianteResponseDTO>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 4. GET ALL (GET)
        // ---------------------------------------------------------
        public async Task<IEnumerable<EstudianteResponseDTO>> GetEstudiantesAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Constant.EstudianteRoute);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<EstudianteResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // 5. UPDATE (PUT)
        // ---------------------------------------------------------
        public async Task<GenericResponse> UpdateEstudianteAsync(CreateEstudianteRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();

                var response = await client.PutAsJsonAsync(Constant.EstudianteRoute, request);

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