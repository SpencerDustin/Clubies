using Clubies.Components;
using MongoDB.Driver;
using Clubies.Services;
using Clubies.Services.Interfaces;

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

// Add Hashing service
builder.Services.AddSingleton<IHashingService, HashingService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

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
