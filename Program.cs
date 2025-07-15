using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using Ramon_Gonzalez_AP1_P2.Components;
using Ramon_Gonzalez_AP1_P2.Context;
using Ramon_Gonzalez_AP1_P2.Service;
using Ramon_Gonzalez_AP1_P2.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlConStr");  

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<EntradasService>();
builder.Services.AddScoped<ProductosService>();

builder.Services.AddDbContextFactory<Contexto>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
