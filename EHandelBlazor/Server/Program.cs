global using EHandelBlazor.Server.Daten;
global using EHandelBlazor.Server.Dienste.KategorieDienst;
global using EHandelBlazor.Server.Dienste.ProduktDienst;
global using EHandelBlazor.Server.Dienste.WarenKorbDienst;
global using EHandelBlazor.Server.Dienste.AuthDienst;
global using EHandelBlazor.Shared;
global using Microsoft.EntityFrameworkCore;

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


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
