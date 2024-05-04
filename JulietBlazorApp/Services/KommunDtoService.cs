using BaseLibrary.DTO;
using System.Net.Http.Json;


public class KommunDtoService
{
    private readonly HttpClient _httpClient;

    public KommunDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<KommunDto>> GetkommunerAsync()
    {
        try
        {
            var kommuner = await _httpClient.GetFromJsonAsync<IEnumerable<KommunDto>>($"api/KommunDto");
            return kommuner;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

