using BaseLibrary.DTO;
using System.Net.Http.Json;


public class BostadDtoService
{
    private readonly HttpClient _httpClient;

    public BostadDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BostadDto>> GetBostäderAsync()
    {
        try
        {
            var bostäder = await _httpClient.GetFromJsonAsync<IEnumerable<BostadDto>>("api/BostadDto");
            return bostäder;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

