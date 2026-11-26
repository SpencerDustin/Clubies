using Clubies.Components;
using MongoDB.Driver;
using Clubies.Services;
using Clubies.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Clubies.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Clubies.Models;


var builder = WebApplication.CreateBuilder(args);

// Reads .env file and loads it into environmental variables
DotNetEnv.Env.Load();

// Grabbing connection string and database name from .env file.
string connectionString =
    Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Missing MongoDB Connection String");

string databaseName =
    Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME")
    ?? throw new InvalidOperationException("Missing MongoDB database name.");


// Connects with Atlas
builder.Services.AddSingleton<IMongoClient>(
    new MongoClient(connectionString)
);

// Connects with specific database in Atlas
builder.Services.AddSingleton<IMongoDatabase>(serviceProvider =>
{
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    return client.GetDatabase(databaseName);
});

builder.Services.AddSingleton<MongoDbTestService>();

builder.Services.AddSingleton<IHashingService, HashingService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IClubEventService, ClubEventService>();
builder.Services.AddScoped<IChannelService, ChannelService>();
builder.Services.AddScoped<IClubAuthorityService, ClubAuthorityService>();

builder.Services.AddDbContextFactory<MongoDbContext>(options =>
{
    options.UseMongoDB(connectionString, databaseName);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Adding cookies authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Using authentication for cookies
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", async ([FromForm] String username, [FromForm] String password, IUserService userService, HttpContext context) =>
{
    User? user = await userService.GetByUsername(username);

    if (user == null || !await userService.ValidateLogin(user, password))
        return Results.Redirect("/login?failed=true");

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username)
    };

    // Authenticated identity
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    var principal = new ClaimsPrincipal(identity);

    await context.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        principal);

    return Results.Redirect("/");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
