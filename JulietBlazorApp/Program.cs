using Blazored.LocalStorage;
using JulietBlazorApp;
using JulietBlazorApp.Constants;
using JulietBlazorApp.Providers;
using JulietBlazorApp.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<BostadDtoService>();
builder.Services.AddScoped<BostadBildDtoService>();
builder.Services.AddScoped<BostadKategoriDtoService>();
builder.Services.AddScoped<KommunDtoService>();
builder.Services.AddScoped<AuthenticationService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7045/") });




//builder.Services.AddTransient<AuthenticationHandler>();

//builder.Services.AddHttpClient("ServerApi")
//                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""))
//                .AddHttpMessageHandler<AuthenticationHandler>();

builder.Services.AddHttpClient(AppConstants.ServerApi)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""));
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<ApiAuthenticationStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(p => p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
