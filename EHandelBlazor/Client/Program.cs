global using EHandelBlazor.Shared;
global using System.Net.Http.Json;
global using EHandelBlazor.Client.Dienste.ProduktDienst;
global using EHandelBlazor.Client.Dienste.KategorieDienst;
global using EHandelBlazor.Client.Dienste.WarenKorbDienst;
global using EHandelBlazor.Client.Dienste.AuthDienst;
global using Microsoft.AspNetCore.Components.Authorization;
using EHandelBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProduktDienst, ProduktDienst>();
builder.Services.AddScoped<IKategorieDienst, KategorieDienst>();
builder.Services.AddScoped<IWarenKorbDienst, WarenKorbDienst>();
builder.Services.AddScoped<IAuthDienst, AuthDienst>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, SpezielleAuthStateProvider>();

await builder.Build().RunAsync();
