using Application.Contracts.AsignaturaEquivalencia;
using Application.DTOs.Request.AsignaturasEquivalencia;
using Application.DTOs.Response;
using Application.DTOs.Response.AsignaturaEquivalencia;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AsignaturaEquivalenciaService(HttpClientService httpClientService) : IAsignaturaEquivalenciaService
    {
        private const string Route = Constant.AsignaturaEquivalenciaRoute; // Agrégalo a Constants

        public async Task<GenericResponse> AddAsignaturaEquivalenciaAsync(AsignaturaEquivalenciaRequestDTO model)
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

        public async Task<bool> AsignaturaEquivalenciaExistsAsync(int asignaturaId, int asignaturaEquivalenteId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta sugerida: api/equivalencia/exists/10/20
                var response = await client.GetAsync($"{Route}/exists/{asignaturaId}/{asignaturaEquivalenteId}");

                if (!response.IsSuccessStatusCode) return false;

                return await response.Content.ReadFromJsonAsync<bool>();
            }
            catch { return false; }
        }

        public async Task<GenericResponse> DeleteAsignaturaEquivalenciaAsync(int asignaturaId, int asignaturaEquivalenteId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta para borrar clave compuesta: api/equivalencia/10/20
                var response = await client.DeleteAsync($"{Route}/{asignaturaId}/{asignaturaEquivalenteId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) return new GenericResponse(Flag: false, Message: error);

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex) { return new GenericResponse(Flag: false, Message: ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetAsignaturasEquivalenciasAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaEquivalenciaResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetEquivalenciasByAsignaturaEquivalenteIdAsync(int asignaturaEquivalenteId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta: api/equivalencia/equivalente/20
                var response = await client.GetAsync($"{Route}/equivalente/{asignaturaEquivalenteId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaEquivalenciaResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaEquivalenciaResponseDTO>> GetEquivalenciasByAsignaturaIdAsync(int asignaturaId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                // Ruta: api/equivalencia/asignatura/10
                var response = await client.GetAsync($"{Route}/asignatura/{asignaturaId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaEquivalenciaResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? null : $"Error: {response.StatusCode}, {response.ReasonPhrase}";
        }
    }
}