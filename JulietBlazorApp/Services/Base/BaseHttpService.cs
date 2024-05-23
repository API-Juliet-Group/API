using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace JulietBlazorApp.Services.Base
{
    public class BaseHttpService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IClient client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            this.localStorage = localStorage;
            this.client = client;
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if(token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
