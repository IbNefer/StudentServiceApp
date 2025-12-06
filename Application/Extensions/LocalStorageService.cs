using Application.DTOs.Request.Account;
using NetcodeHub.Packages.Extensions.LocalStorage;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Extensions
{
    public class LocalStorageService(ILocalStorageService localStorageService)
    {
        public async Task<string?> GetBrowserLocalStorageAsync()
        {
            var tokenModel = await localStorageService.GetEncryptedItemAsStringAsync(Constant.BrowserStorageKey);

            return tokenModel;
        }
        public async Task<LocalStorageDTO> GetModelFromToken()
        {
            try
            {
                var tokenModelString = await GetBrowserLocalStorageAsync();
                if (string.IsNullOrEmpty(tokenModelString) || string.IsNullOrWhiteSpace(tokenModelString))
                    return new LocalStorageDTO();
                //var tokenModel = JsonSerializer.Deserialize<LocalStorageDTO>(tokenModelString!);
                var tokenModel = DeserializeJsonString<LocalStorageDTO>(tokenModelString!);

                return tokenModel!;
            }
            catch
            {
                //Console.WriteLine($"Error deserializing LocalStorageDTO: {ex.Message}");
                return new LocalStorageDTO();
            }
        }

        public async Task SetBrowserLocalStorage(LocalStorageDTO model)
        {
            try
            {
                var tokenModelString = SerializeObj(model);
                await localStorageService.SaveAsEncryptedStringAsync(Constant.BrowserStorageKey, tokenModelString);

            }
            catch
            {
                //Console.WriteLine($"Error serializing LocalStorageDTO: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveBrowserLocalStorage()
        => await localStorageService.DeleteItemAsync(Constant.BrowserStorageKey);

        private static string SerializeObj<T>(T modelObj)
        => JsonSerializer.Serialize(modelObj, GetJsonSerializerOptions());

        private static T DeserializeJsonString<T>(string jsonString)
        => JsonSerializer.Deserialize<T>(jsonString, GetJsonSerializerOptions())!;

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }
    }
}
