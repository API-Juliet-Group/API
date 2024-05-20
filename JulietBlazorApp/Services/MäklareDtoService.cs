﻿using BaseLibrary.DTO;
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

        public async Task<MäklareDto> GetMäklare(string id)
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
    }
}
