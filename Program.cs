using LivepeerTest.Infrastructure.Services.Livepeer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<LivepeerStartStream>();
builder.Services.AddSingleton<StreamResponse>();
// Livepeer apikey
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string apiKey = configuration["Livepeer:ApiKey"];
builder.Services.AddSingleton<LivepeerClient>(sp => new LivepeerClient(apiKey));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
