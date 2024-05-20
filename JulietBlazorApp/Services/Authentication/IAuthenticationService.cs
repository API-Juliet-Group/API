using BaseLibrary.DTO;

namespace JulietBlazorApp.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginRequest loginModel);
        Task<string> LoginAsync(LoginRequest loginModel);
        Task LogoutAsync();
    }
}