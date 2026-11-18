using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// SAST-01 : credential fictif codé en dur
var connectionString = "Server=SERVEUR;Database=DemoDb;User Id=admin;Password=Password123!;";


// SAST-02 : clé API fictive codée en dur
var apiKey = "demo-api-key-123456789";


// SAST-03 : algorithme cryptographique volontairement faible
using var md5 = MD5.Create();
var hash = md5.ComputeHash(
    System.Text.Encoding.UTF8.GetBytes("TestDevSecOps")
);

// SAST-04 : donnée sensible volontairement écrite dans les logs
var password = "Password123!";
Console.WriteLine(password);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
