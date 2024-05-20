using BaseLibrary.DTO;
using Blazored.LocalStorage;
using JulietBlazorApp.Constants;
using JulietBlazorApp.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

namespace JulietBlazorApp.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public event Action<string?>? LoginChange;

        public AuthenticationService(IHttpClientFactory factory, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = factory.CreateClient(AppConstants.ServerApi);
            _localStorageService = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginRequest loginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(LoginRequest loginModel)
        {
            var response = await _httpClient.PostAsync("api/authentication/login", JsonContent.Create(loginModel));

            if (!response.IsSuccessStatusCode)
            {
                throw new UnauthorizedAccessException("Inloggningen misslyckades.");
            }

            var responseContent = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (responseContent == null)
            {
                throw new InvalidDataException();
            }
            await _localStorageService.SetItemAsync(AppConstants.TOKEN_KEY, responseContent.Token);

            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

            //return responseContent.Email;
            return await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetId();
        }

        public async Task LogoutAsync()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task RegisterAsync(MäklareDto mäklareDto)
        {
            var response = await _httpClient.PostAsync("api/authentication/register", JsonContent.Create(mäklareDto));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }

        private static string GetId(string token)
        {
            var jwt = new JwtSecurityToken(token);
            return jwt.Claims.First(c => c.Type == CustomClaimTypes.Uid).Value;
        }

        private static string GetEmail(string token)
        {
            var jwt = new JwtSecurityToken(token);
            return jwt.Claims.First(c => c.Type == ClaimTypes.Email).Value;
        }
    }
}
