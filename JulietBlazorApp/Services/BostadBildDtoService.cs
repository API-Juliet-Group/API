using BaseLibrary.DTO;
using System.Net.Http.Json;


public class BostadBildDtoService
{

    private readonly HttpClient _httpClient;

    public BostadBildDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BostadBildDto>> GetBostadsBilderAsync()
    {
        try
        {
            var bostadsBilder = await _httpClient.GetFromJsonAsync<List<BostadBildDto>>($"api/BostadBildDto");
            return bostadsBilder;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

