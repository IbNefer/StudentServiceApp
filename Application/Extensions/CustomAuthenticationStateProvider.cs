using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public class CustomAuthenticationStateProvider(LocalStorageService localStorageService): AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var tokenModel = await localStorageService.GetModelFromToken();
                var identity = string.IsNullOrEmpty(tokenModel.Token) ? new System.Security.Claims.ClaimsIdentity() :
                    new System.Security.Claims.ClaimsIdentity(ParseClaimsFromJwt(tokenModel.Token), "jwt");
                var user = new System.Security.Claims.ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            catch
            {
                var anonymous = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }
        }

        private IEnumerable<Claim>? ParseClaimsFromJwt(string token)
        {
            throw new NotImplementedException();
        }
    }
}
