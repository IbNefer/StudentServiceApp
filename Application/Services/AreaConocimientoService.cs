using Application.Contracts.AreaConocimiento;
using Application.DTOs.Request.AreaConocimiento;
using Application.DTOs.Response;
using Application.DTOs.Response.AreaConocimiento;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AreaConocimientoService(HttpClientService httpClientService) : IAreaConocimientoService
    {
        private const string Route = Constant.AreaConocimientoRoute;

        public async Task<GenericResponse> AddAreaConocimientoAsync(CreateAreaConocimientoRequestDTO model)
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

        public async Task<GenericResponse> DeleteAreaConocimientoAsync(int id)
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

        public async Task<AreaConocimientoResponseDTO> GetAreaConocimientoByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<AreaConocimientoResponseDTO>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AreaConocimientoResponseDTO>> GetAreasConocimientoAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AreaConocimientoResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<GenericResponse> UpdateAreaConocimientoAsync(CreateAreaConocimientoRequestDTO model)
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