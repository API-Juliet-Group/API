using BaseLibrary.DTO;
using System.Net.Http.Json;


public class BostadBildDtoService
{

    private readonly HttpClient _httpClient;

    public BostadBildDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BostadBildDto>> GetBostadsBilderAsync()
    {
        try
        {
            var bostadsBilder = await _httpClient.GetFromJsonAsync<IEnumerable<BostadBildDto>>($"api/BostadBildDto");
            return bostadsBilder;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<BostadBildDto>> GetBostadensBilderAsync(int id)
    {
        try
        {
            var bostadensBilder = await _httpClient.GetFromJsonAsync<IEnumerable<BostadBildDto>>($"api/BostadBildDto/{id}");
            return bostadensBilder;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AddBostadsBilderAsync(IEnumerable<BostadBildDto> bostadBildDtos)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/BostadBildDto/bulk", bostadBildDtos);
            if(response.IsSuccessStatusCode)
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

    public async Task<bool> AddBostadBildAsync(BostadBildDto bostadBild)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/BostadBildDto/single", bostadBild);
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

    public async Task<bool> RemoveBostadBildAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/BostadBildDto/{id}");

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

