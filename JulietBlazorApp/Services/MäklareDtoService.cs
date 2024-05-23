/*
 * Author: Johan Ahlqvist
 * Edited for use of ServiceClient: Tobias Svensson
 */

using Blazored.LocalStorage;
using JulietBlazorApp.Providers;
using JulietBlazorApp.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;

namespace JulietBlazorApp.Services
{
    public class MäklareDtoService : BaseHttpService, IMäklareDtoService
    {
        private readonly IClient httpClient;

        public MäklareDtoService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.httpClient = client;
        }

        public async Task<MäklareDto> GetMäklareAsync(string mäklarId)
        {
            try
            {
                var mäklare = await httpClient.MäklareGETAsync(mäklarId);
                return mäklare;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateMäklareAsync(MäklareDto mäklareDto, string mäklarId)
        {
            try
            {
                await GetBearerToken();
                await httpClient.MäklarePUTAsync(mäklarId, mäklareDto);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
