using BaseLibrary.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class BostadService
{
    private readonly HttpClient _httpClient;

    public BostadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Bostad>> GetBostäderAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Bostad>>("api/Bostad");
        return result ?? new List<Bostad>();
    }
}
