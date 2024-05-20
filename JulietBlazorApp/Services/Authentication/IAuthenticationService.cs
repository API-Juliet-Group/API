/*
 * Author: Johan Ahlqvist
 */

using BaseLibrary.DTO;

namespace JulietBlazorApp.Services.Authentication
{
    public interface IAuthenticationService
    {
        ValueTask<string> GetJwtAsync();
        Task<bool> AuthenticateAsync(LoginRequest loginModel);
        Task<string> LoginAsync(LoginRequest loginModel);
        Task LogoutAsync();
        Task RegisterAsync(MäklareDto mäklareDto);
    }
}