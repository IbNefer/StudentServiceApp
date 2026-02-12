using Application.DTOs.Request.Account;
using Application.Services;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;


namespace Application.Extensions
{
    public class CustomHttpHandler(LocalStorageService localStorageService, NavigationManager navigationManager, IServiceAccount serviceAccount) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                bool LoginUrl = request.RequestUri!.AbsolutePath.Contains(Constant.LoginRoute);
                bool RegisterUrl = request.RequestUri!.AbsolutePath.Contains(Constant.RegisterRoute);
                bool RefreshTokenUrl = request.RequestUri!.AbsolutePath.Contains(Constant.RefreshTokenRoute);
                bool AdminCreateUrl = request.RequestUri!.AbsolutePath.Contains(Constant.CreateAdminRoute);

                if (LoginUrl || RegisterUrl || RefreshTokenUrl || AdminCreateUrl)
                {
                    return await base.SendAsync(request, cancellationToken);
                }


                var resullt = await base.SendAsync(request, cancellationToken);
                if (resullt.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var tokenModel = await localStorageService.GetModelFromToken();
                    if (tokenModel == null) return resullt;

                    var refreshResult = await GetRefreshToken(tokenModel.Refresh!);
                    if (string.IsNullOrEmpty(refreshResult))
                    {
                        await ClearBrowserStorage();
                        return resullt;
                    }

                    request.Headers.Authorization = new AuthenticationHeaderValue(Constant.HttpClientHeaderScheme, refreshResult);
                    return await base.SendAsync(request, cancellationToken);
                }
                return resullt; 

            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private async Task<string> GetRefreshToken(string refreshToken)
        {
            try
            {
                var response = await serviceAccount.RefreshTokenAsync(new RefreshTokenDTO() { Token = refreshToken });
                if (response == null || response.Token == null)
                {
                    await ClearBrowserStorage();
                    return null;
                }
                await localStorageService.RemoveBrowserLocalStorage();
                await localStorageService.SetBrowserLocalStorage(new LocalStorageDTO() { Refresh = response!.RefreshToken, Token = response.Token });
                return response.Token;
            }
            catch 
            {
                return null;
            }

        }

        private async Task ClearBrowserStorage()
        {
            await localStorageService.RemoveBrowserLocalStorage();
            navigationManager.NavigateTo(navigationManager.BaseUri,true, true);
        }
    }
}
