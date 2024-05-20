/*
 * Author: Johan Ahlqvist
 * Edited for Get and Update: Tobias Svensson
 */

using BaseLibrary.DTO;
using JulietBlazorApp.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace JulietBlazorApp.Services
{
    public class MäklareDtoService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public MäklareDtoService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
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
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await ((ApiAuthenticationStateProvider)_authenticationStateProvider).GetToken());
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
