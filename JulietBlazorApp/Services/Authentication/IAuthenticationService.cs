/*
 * Author: Johan Ahlqvist
 */

using JulietBlazorApp.Services.Base;

namespace JulietBlazorApp.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginRequest loginModel);
        Task LogoutAsync();
    }
}