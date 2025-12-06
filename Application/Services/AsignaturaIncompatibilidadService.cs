using Application.Contracts.AsignaturaIncompatibilidad;
using Application.DTOs.Request.AsignaturaIncompatibilidad;
using Application.DTOs.Response;
using Application.DTOs.Response.AsignaturaIncompatibilidad;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AsignaturaIncompatibilidadService(HttpClientService httpClientService) : IAsignaturaIncompatibilidadService
    {
        private const string Route = Constant.AsignaturaIncompatibilidadRoute; // Agrégalo a Constants

        public async Task<GenericResponse> AddAsignaturaIncompatibilidadAsync(AsignaturaIncompatibilidadRequestDTO model)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PostAsJsonAsync(Route, model);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) return new GenericResponse(Flag: false, Message: error);

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex) { return new GenericResponse(Flag: false, Message: ex.Message); }
        }

        public async Task<bool> AsignaturaIncompatibilidadExistsAsync(int asignaturaId, int asignaturaIncompatibleId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/exists/{asignaturaId}/{asignaturaIncompatibleId}");

                if (!response.IsSuccessStatusCode) return false;

                return await response.Content.ReadFromJsonAsync<bool>();
            }
            catch { return false; }
        }

        public async Task<GenericResponse> DeleteAsignaturaIncompatibilidadAsync(int asignaturaId, int asignaturaIncompatibleId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.DeleteAsync($"{Route}/{asignaturaId}/{asignaturaIncompatibleId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) return new GenericResponse(Flag: false, Message: error);

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex) { return new GenericResponse(Flag: false, Message: ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetAsignaturasIncompatibilidadsAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaIncompatibilidadResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetIncompatibilidadsByAsignaturaIdAsync(int asignaturaId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/asignatura/{asignaturaId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaIncompatibilidadResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaIncompatibilidadResponseDTO>> GetIncompatibilidadsByAsignaturaIncompatibleIdAsync(int asignaturaIncompatibleId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/incompatible/{asignaturaIncompatibleId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaIncompatibilidadResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? null : $"Error: {response.StatusCode}, {response.ReasonPhrase}";
        }
    }
}