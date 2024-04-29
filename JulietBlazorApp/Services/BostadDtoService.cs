using BaseLibrary.DTO;
using System.Net.Http.Json;


public class BostadDtoService
{
    private readonly HttpClient _httpClient;

    public BostadDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BostadDto>> GetBostäderAsync()
    {
        try
        {
            var bostäder = await _httpClient.GetFromJsonAsync<List<BostadDto>>("api/BostadDto");
            return bostäder;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

