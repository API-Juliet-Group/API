/*
    Author: Tobias Svensson
*/
using BaseLibrary.DTO;
using System.Net.Http.Json;


public class BostadKategoriDtoService
{
    private readonly HttpClient _httpClient;

    public BostadKategoriDtoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BostadKategoriDto>> GetBostadKategorierAsync()
    {
        try
        {
            var bostadKategorier = await _httpClient.GetFromJsonAsync<IEnumerable<BostadKategoriDto>>($"api/BostadKategoriDto");
            return bostadKategorier;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

