using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container. database service injection.

            builder.Services.AddControllers();
			//database service  injection
			//var dbHost = "YANNOH";
			//var dbPassword = "Pass@123";
			//var dbName = "dms_customer";
			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");
			var connectionString= $"Data Source ={dbHost};Initial Catalog={dbName}; User ID =sa;Password=Pass@123;TrustServerCertificate=true;";
			builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));
			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}