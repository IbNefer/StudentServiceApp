using Application.DTOs.Request.Titulacion;
using Application.DTOs.Response;
using Application.DTOs.Response.Titulacion;
using Application.Extensions; 
using System.Net.Http.Json;

namespace Application.Services.Titulacion
{
    public class TitulacionService(HttpClientService httpClientService) : ITitulacionService
    {
        public async Task<GenericResponse> AddTitulacionAsync(CreateTitulacionRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();

                var response = await client.PostAsJsonAsync(Constant.TitulacionRoute, request);

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

        
        public async Task<IEnumerable<TitulacionResponseDTO>> GetTitulacionesAsync()
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync(Constant.TitulacionRoute);

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<TitulacionResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<TitulacionResponseDTO> GetTitulacionByIdAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.GetAsync($"{Constant.TitulacionRoute}/{id}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<TitulacionResponseDTO>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<GenericResponse> UpdateTitulacionAsync(int id, CreateTitulacionRequestDTO request)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();
                var response = await client.PutAsJsonAsync($"{Constant.TitulacionRoute}/{id}", request);

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

        public async Task<GenericResponse> DeleteTitulacionAsync(int id)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();

                var response = await client.DeleteAsync($"{Constant.TitulacionRoute}/{id}");

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
        // OPCIONAL: Get por Departamento
        // ---------------------------------------------------------
        public async Task<IEnumerable<TitulacionResponseDTO>> GetTitulacionesByDepartamentoIdAsync(int departamentoId)
        {
            try
            {
                var client = await httpClientService.GetPrivateClient();

                var response = await client.GetAsync($"{Constant.TitulacionRoute}/departamento/{departamentoId}");

                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<TitulacionResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // ---------------------------------------------------------
        // HELPER PARA VERIFICAR ERRORES
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