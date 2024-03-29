global using EHandelBlazor.Server.Daten;
global using EHandelBlazor.Server.Dienste.AuthDienst;
global using EHandelBlazor.Server.Dienste.KategorieDienst;
global using EHandelBlazor.Server.Dienste.ProduktDienst;
global using EHandelBlazor.Server.Dienste.WarenKorbDienst;
global using EHandelBlazor.Server.Dienste.BestellungDienst;
global using EHandelBlazor.Server.Dienste.ZahlungDienst;
global using EHandelBlazor.Server.Dienste.AdresseDienst;
global using EHandelBlazor.Shared.Modelle;
global using EHandelBlazor.Shared.D�oe;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Cryptography;
global using Stripe.Checkout;
global using Stripe;
global using EHandelBlazor.Server.Dienste.ProduktArtDienst;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatenKontext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlVerbindung"));
});

builder.Services.AddScoped<IProduktDienst, ProduktDienst>();
builder.Services.AddScoped<IKategorieDienst, KategorieDienst>();
builder.Services.AddScoped<IWarenKorbDienst, WarenKorbDienst>();
builder.Services.AddScoped<IAuthDienst, AuthDienst>();
builder.Services.AddScoped<IBestellungDienst, BestellungDienst>();
builder.Services.AddScoped<IZahlungDienst, ZahlungDienst>();
builder.Services.AddScoped<IAdresseDienst, AdresseDienst>();
builder.Services.AddScoped<IProduktArtDienst, ProduktArtDienst>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppEinstellungen:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
