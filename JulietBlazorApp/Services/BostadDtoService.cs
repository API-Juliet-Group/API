using BaseLibrary.DTO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;


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

    public async Task<bool> AddBostadAsync(BostadDto bostadDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/BostadDto",bostadDto);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteBostadAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/BostadDto/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}

