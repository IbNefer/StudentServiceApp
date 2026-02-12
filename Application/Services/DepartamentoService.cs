using Application.Contracts.Departamento;
using Application.DTOs.Request.Departamento;
using Application.DTOs.Response;
using Application.DTOs.Response.Departamento;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class DepartamentoService(HttpClientService httpClientService) : IDepartamentoService
    {
        private const string Route = Constant.DepartamentoRoute; 

        public async Task<GenericResponse> AddDepartamentoAsync(CreateDepartamentoRequestDTO model)
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

        public async Task<GenericResponse> DeleteDepartamentoAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.DeleteAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) return new GenericResponse(Flag: false, Message: error);

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex) { return new GenericResponse(Flag: false, Message: ex.Message); }
        }

        public async Task<DepartamentoResponseDTO> GetDepartamentoByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<DepartamentoResponseDTO>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<DepartamentoResponseDTO>> GetDepartamentosAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<DepartamentoResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Asumiendo que el ID va en el DTO o se ajusta en la ruta, aquí uso el DTO directo al body
        public async Task<GenericResponse> UpdateDepartamentoAsync(CreateDepartamentoRequestDTO model)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PutAsJsonAsync(Route, model);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) return new GenericResponse(Flag: false, Message: error);

                return (await response.Content.ReadFromJsonAsync<GenericResponse>())!;
            }
            catch (Exception ex) { return new GenericResponse(Flag: false, Message: ex.Message); }
        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? null : $"Error: {response.StatusCode}, {response.ReasonPhrase}";
        }
    }
}