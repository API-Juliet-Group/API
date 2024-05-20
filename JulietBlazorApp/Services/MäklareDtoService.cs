/*
 * Author: Johan Ahlqvist
 */

using BaseLibrary.DTO;
using System.Net.Http.Json;

namespace JulietBlazorApp.Services
{
    public class MäklareDtoService
    {
        private readonly HttpClient _httpClient;

        public MäklareDtoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MäklareDto> GetMäklareAsync(string id)
        {
            try
            {
                var mäklare = await _httpClient.GetFromJsonAsync<MäklareDto>($"api/Mäklare/{id}");
                return mäklare;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMäklareAsync(MäklareDto mäklareDto, string mäklarId)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Mäklare/{mäklarId}", mäklareDto);

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
}
