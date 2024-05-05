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

    public async Task<BostadDto> GetBostadAsync(int id)
    {
        try
        {
            var bostad = await _httpClient.GetFromJsonAsync<BostadDto>($"api/BostadDto/{id}");
            return bostad;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteBostadAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"api/BostadDto/{id}");
        }
        catch (Exception)
        {
            throw;
        }
    }
}

