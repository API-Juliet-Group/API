using Blazored.LocalStorage;
using JulietBlazorApp;
using JulietBlazorApp.Constants;
using JulietBlazorApp.Providers;
using JulietBlazorApp.Services;
using JulietBlazorApp.Services.Authentication;
using JulietBlazorApp.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<BostadDtoService>();
builder.Services.AddScoped<BostadBildDtoService>();
builder.Services.AddScoped<BostadKategoriDtoService>();
builder.Services.AddScoped<MäklareDtoService>();
builder.Services.AddScoped<KommunDtoService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<MäklareDtoService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7045/") });

/*
 * Edited for identity: Johan Ahlqvist
 * Edited for use of ServiceClient: Tobias Svensson
 */
builder.Services.AddHttpClient(AppConstants.ServerApi)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""));
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IClient, Client>();
builder.Services.AddTransient<IMäklareDtoService, MäklareDtoService>();

await builder.Build().RunAsync();
