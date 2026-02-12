using Application.Contracts.Horario;
using Application.DTOs.Request.Horario;
using Application.DTOs.Response;
using Application.DTOs.Response.Horario;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class HorarioService(HttpClientService httpClientService) : IHorarioService
    {
        private const string Route = Constant.HorarioRoute;

        public async Task<GenericResponse> AddHorarioAsync(CreateHorarioRequestDTO model)
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

        public async Task<GenericResponse> DeleteHorarioAsync(int id)
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

        public async Task<AsignaturaConHorarioResponseDTO> GetHorarioByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Route}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<AsignaturaConHorarioResponseDTO>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<AsignaturaConHorarioResponseDTO>> GetHorariosAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Route);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return (await response.Content.ReadFromJsonAsync<IEnumerable<AsignaturaConHorarioResponseDTO>>())!;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<GenericResponse> UpdateHorarioAsync(CreateHorarioRequestDTO model)
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