using ProductWebApi;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//database service  injection
//var dbHost = "localhost";
//var dbPassword = "";
//var dbName = "dms_customer";
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = $"server={dbHost};database={dbName};user=root;Password={dbPassword};";
builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
