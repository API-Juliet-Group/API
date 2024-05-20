namespace JulietBlazorApp.Services
{
    public class MäklareDtoService
    {
        private readonly HttpClient _httpClient;

        public MäklareDtoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


    }
}
