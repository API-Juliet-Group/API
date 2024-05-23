/*
 * Author: Johan Ahlqvist
 * Edited for use of ServiceClient: Tobias Svensson
 */

using Blazored.LocalStorage;
using JulietBlazorApp.Constants;
using JulietBlazorApp.Providers;
using JulietBlazorApp.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

namespace JulietBlazorApp.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public event Action<string?>? LoginChange;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginRequest loginModel)
        {
            try
            {
            var response = await httpClient.LoginAsync(loginModel);

            await localStorage.SetItemAsync("accessToken", response.Token);

            await((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();

            return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Authentication failed: {ex.Message}");

                throw;
            }
        }


        public async Task LogoutAsync()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }


    }
}
